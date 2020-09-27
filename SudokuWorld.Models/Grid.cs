using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace SudokuWorld.Models
{
    public class Grid
    {
        public int Id { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public string Level { get; set; }
        public int NbTimesCompleted { get; set; }
        public int Record { get; set; }
    }
}
