using SudokuWorld.DataAccess.Data;
using SudokuWorld.DataAccess.Repository.IRepository;
using SudokuWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace SudokuWorld.DataAccess.Repository
{
    public class GridRepository : Repository<Grid>,IGridRepository
    {
        private readonly ApplicationDbContext _db;

        public GridRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Grid grid)
        {
            var gridFromDb = _db.Grids.FirstOrDefault(s => s.Id == grid.Id);
            if (gridFromDb != null)
            {
                gridFromDb.Record = grid.Record;
                gridFromDb.NbTimesCompleted += 1;
                _db.SaveChanges();
            }
        }

        public IOrderedEnumerable<Grid> GetGrids(string level,Claim claim)
        {
            var grids = _db.Grids.Where(g => g.Difficulty.Level == level).ToList().OrderBy(g => g.Id);
            if (claim == null)
            {
                return grids;
            }
            int[] idsGrids = _db.Results.Where(r => r.UserId == claim.Value && (r.SucceedTime!=9999 || r.IsGiveUp==true)).Select(r => r.GridId).ToArray();
            for(int i = 0; i < grids.Count(); i++)
            {
                if (idsGrids.Contains(grids.ElementAt(i).Id))
                {
                    grids.ElementAt(i).IsDoneByUser = true;
                }
            }
            return grids;

        }

        public string AddSubmit(int id,int time)
        {
            string information = "Bravo !";
            var gridFromDb = _db.Grids.FirstOrDefault(s => s.Id == id);
            if (gridFromDb != null)
            {
                if(gridFromDb.Record==0 || gridFromDb.Record > time)
                {
                    gridFromDb.Record = time;
                    information = "Incroyable vous avez battu le record !";
                }
                gridFromDb.NbTimesCompleted += 1;
                _db.SaveChanges();
            }
            return information;
        }

        public int GetNewGridId(Claim claim, int id)
        {
            string gridNowLevel = _db.Grids.Where(g => g.Id == id).Select(g=>g.Difficulty.Level).FirstOrDefault();
            List<int> idsGridFromDb = _db.Grids.Where(g=>g.Difficulty.Level==gridNowLevel && g.Id!=id).OrderBy(g => g.Record).Select(g=>g.Id).ToList();
            if (idsGridFromDb.Count>0)
            {
                foreach(int gId in idsGridFromDb)
                {
                    if (!GridIsDoneByUser(claim, gId))
                    {
                        return gId;
                    }
                }
            }
            idsGridFromDb = _db.Grids.Where(g => g.Id != id).OrderBy(g => g.Difficulty.Id).Select(g => g.Id).ToList();
            foreach (int gId in idsGridFromDb)
            {
                if (!GridIsDoneByUser(claim, gId))
                {
                    return gId;
                }
            }
            return id;
        }

        public bool GridIsDoneByUser(Claim claim, int idGrid)
        {
            if (claim == null)
            {
                return false;
            }
            return _db.Results.Where(r => r.GridId == idGrid && r.UserId == claim.Value && (r.SucceedTime != 9999 || r.IsGiveUp)).Count() > 0;
        }
    }
}
