using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SudokuWorld.Models
{
    public class Results
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public int GridId { get; set; }

        public Grid Grid { get; set; }

        public int SucceedTime { get; set; }

        public bool IsGiveUp { get; set; }

        public int NumberOfAttemps { get; set; }

    }
}
