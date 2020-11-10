using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int? DifficultyId { get; set; }
        public Difficulty Difficulty { get; set; }
        public int NbTimesCompleted { get; set; }
        public int Record { get; set; }
        public List<Results> Results { get; set; }

        public List<Comments> Comments { get; set; }

        [NotMapped]
        public bool IsDoneByUser { get; set; } = false;
    }
}
