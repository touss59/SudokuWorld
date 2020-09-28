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
            var objFromDb = _db.Grids.FirstOrDefault(s => s.Id == grid.Id);
            if (objFromDb != null)
            {
                objFromDb.Record = grid.Record;
                objFromDb.NbTimesCompleted += 1;
                _db.SaveChanges();
            }
        }
    }
}
