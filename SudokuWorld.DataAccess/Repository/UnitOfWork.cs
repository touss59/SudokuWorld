using BulkyBook.DataAccess.Repository;
using SudokuWorld.DataAccess.Data;
using SudokuWorld.DataAccess.Repository.IRepository;
using SudokuWorld.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuWorld.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Grid = new GridRepository(_db);
            SP_Call = new SP_Call(_db);
        }

        public IGridRepository Grid { get; private set; }

        public ISP_Call SP_Call { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
