using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SudokuWorld.DataAccess.Data;
using SudokuWorld.DataAccess.Repository;

namespace SudokuWorld.Areas.Players.Controllers
{
    [Area("Players")]
    public class GrilleController : Controller
    {
        private readonly ApplicationDbContext _db;

        public GrilleController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(int id)
        {
            GridRepository gridRepository = new GridRepository(_db);
            var grid = gridRepository.Get(id);
            return View(grid);
        }
    }
}