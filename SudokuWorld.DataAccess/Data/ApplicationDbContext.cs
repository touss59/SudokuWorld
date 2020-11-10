using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SudokuWorld.DataAccess.Migrations;
using SudokuWorld.Models;

namespace SudokuWorld.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SudokuWorld;Trusted_Connection=True;");
        //}

        public DbSet<Grid> Grids { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Results> Results { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Rank> Ranks { get; set; }
    }
}
