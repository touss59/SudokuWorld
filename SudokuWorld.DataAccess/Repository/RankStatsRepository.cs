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
    public class RankStatsRepository : Repository<ResultsRepository>
    {
        private readonly ApplicationDbContext _db;

        public RankStatsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public List<Rank> GetRankUsers()
        {
            List<Rank> ranks = _db.Ranks.OrderByDescending(r=>r.XP).ToList();

            return ranks;
        }


    }
}
