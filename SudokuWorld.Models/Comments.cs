using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;


namespace SudokuWorld.Models
{
    public class Comments
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public int GridId { get; set; }

        public Grid Grid { get; set; }

        public int Satisfaction { get; set; }

        public string Quote { get; set; }

        public int GridLevel { get; set; }


    }
}
