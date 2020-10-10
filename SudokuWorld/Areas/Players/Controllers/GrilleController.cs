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

        [HttpPost]
        public string SubmitGrid()
        {
            int id = Convert.ToInt32(Request.Form["id"]);
            int time = Convert.ToInt32(Request.Form["timer"]);
            GridRepository gridRepository = new GridRepository(_db);
            string info = gridRepository.AddSubmit(id, time);
            return info;
        }

        [HttpGet]
        public ActionResult NewGrid(int id)
        {
            GridRepository gridRepository = new GridRepository(_db);
            int newId = gridRepository.GetNewGrid(id);
            return RedirectToAction("Index", new { id = newId });
        }
    }
}