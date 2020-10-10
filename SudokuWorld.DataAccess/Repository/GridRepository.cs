using SudokuWorld.DataAccess.Data;
using SudokuWorld.DataAccess.Repository.IRepository;
using SudokuWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public int GetNewGrid(int id)
        {
            int newId=id;
            string gridNowLevel = _db.Grids.Where(g => g.Id == id).Select(g=>g.Level).FirstOrDefault();
            int idGridFromDb = _db.Grids.Where(g=>g.Level==gridNowLevel && g.Id!=id).OrderBy(g => g.Record).Select(g=>g.Id).FirstOrDefault();
            if (idGridFromDb == 0)
            {
                idGridFromDb= _db.Grids.Where(g =>g.Id != id).OrderBy(g => g.Record).Select(g => g.Id).FirstOrDefault();
            }
            newId = idGridFromDb;
            return newId;
        }
    }
}
