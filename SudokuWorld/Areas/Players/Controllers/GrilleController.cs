using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SudokuWorld.DataAccess.Data;
using SudokuWorld.DataAccess.Repository;
using SudokuWorld.Models;
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
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            int id = Convert.ToInt32(Request.Form["id"]);
            int time = Convert.ToInt32(Request.Form["timer"]);
            string numbers = Request.Form["numbers"];
            GridRepository gridRepository = new GridRepository(_db);
            ResultsRepository resultsRepository = new ResultsRepository(_db);
            string initialgrid = gridRepository.Get(id).Value;
            string result = CheckSudoku.Solve(initialgrid);
            string info = "La grille a été mal complétée";
            if (result == numbers)
            {
                info = gridRepository.AddSubmit(id, time);
                if(claim!=null)
                    resultsRepository.AddResult(id, claim, time, false,claimsIdentity); 
            }
            if (numbers == "")
            {
                info = "Voici la correction";
                if(claim!=null)
                    resultsRepository.AddResult(id, claim, 9999, true, claimsIdentity);
            }
            if(numbers!= "" && numbers != result)
            {
                result = CheckSudoku.GetErrors(result, numbers);
                if(claim!=null)
                    resultsRepository.AddResult(id, claim, 9999, false, claimsIdentity);
            }
            return Json(new { info, result });
        }

        [HttpGet]
        public ActionResult NewGrid(int id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            GridRepository gridRepository = new GridRepository(_db);
            int newId = gridRepository.GetNewGridId(claim, id);
            return RedirectToAction("Index", new { id = newId });
        }
    }
}