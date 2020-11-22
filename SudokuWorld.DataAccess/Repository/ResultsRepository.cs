using SudokuWorld.DataAccess.Data;
using SudokuWorld.DataAccess.Migrations;
using SudokuWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace SudokuWorld.DataAccess.Repository
{
    public class ResultsRepository : Repository<ResultsRepository>
    {
        private readonly ApplicationDbContext _db;

        public ResultsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void AddResult(int gridId, Claim claim, int succedTime,bool isGiveUpd,ClaimsIdentity claimsIdentity)
        {
            Results results = _db.Results.Where(r => r.UserId == claim.Value && r.GridId == gridId).FirstOrDefault();
            if (results != null)
            {
                results.SucceedTime = succedTime;
                results.IsGiveUp = isGiveUpd;
                results.NumberOfAttemps += 1;
                _db.SaveChanges();
                return;
            }
            Results newResults = new Results();
            newResults.GridId = gridId;
            newResults.UserId = claim.Value;
            newResults.SucceedTime = succedTime;
            newResults.IsGiveUp = isGiveUpd;
            newResults.NumberOfAttemps=1;
            if (succedTime != 9999)
            {
                int xpGrid = _db.Grids.Where(g => g.Id == gridId).Select(g => g.Difficulty.XpGiven).FirstOrDefault();
                Rank rank = _db.Ranks.Where(r => r.UserId == claim.Value).FirstOrDefault();
                if (rank != null)
                {
                    rank.XP += xpGrid;
                }
                else
                {
                    Rank newRank = new Rank { UserId = claim.Value, XP = xpGrid, UserName=claimsIdentity.Name};
                    _db.Ranks.Add(newRank);
                }
            }
            _db.Results.Add(newResults);
            _db.SaveChanges();
        }
    }
}
