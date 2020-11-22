using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
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
    public class RankStatsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public RankStatsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Ranks()
        {
            RankStatsRepository rankStatsRepository = new RankStatsRepository(_db);
            List<Rank> ranks = rankStatsRepository.GetRankUsers();
            return View(ranks);
        }
    }
}
