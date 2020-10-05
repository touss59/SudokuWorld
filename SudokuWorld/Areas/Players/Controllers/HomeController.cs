using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;
using SudokuWorld.DataAccess.Data;
using SudokuWorld.DataAccess.Repository;
using SudokuWorld.Models;
using SudokuWorld.Models.ViewModels;

namespace SudokuWorld.Areas.Players.Controllers
{
    [Area("Players")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Grids(string level)
        {
            GridRepository gridRepository = new GridRepository(_db);
            var grids = gridRepository.GetAll(g => g.Level == level,g=>g.OrderBy(g=>g.Id));
            return View(grids);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
