using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SudokuWorld.DataAccess.Data;
using SudokuWorld.DataAccess.Repository;
using SudokuWorld.Utility;

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
        public JsonResult SubmitGrid()
        {
            int id = Convert.ToInt32(Request.Form["id"]);
            int time = Convert.ToInt32(Request.Form["timer"]);
            string numbers = Request.Form["numbers"];
            GridRepository gridRepository = new GridRepository(_db);
            string initalgrid = gridRepository.Get(id).Value;
            string result = CheckSudoku.Solve(initalgrid);
            string info = "La grille a été mal complétée";
            if (result == numbers)
            {
            info = gridRepository.AddSubmit(id, time);
            }
            if (numbers == "")
            {
                info = "Voici la correction";
            }
            if(numbers!= "" && numbers != result)
            {
                result = CheckSudoku.GetErrors(result, numbers);
            }
            return Json(new { info, result });
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