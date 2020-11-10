using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace SudokuWorld.Models
{
    public class Difficulty
    {
        public int Id { get; set; }
        public string Level { get; set; }
        public int XpGiven { get; set; }
    }
}
