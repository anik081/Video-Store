using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Video_Store.Models.Data
{
    [Table("Movies")]
    public class MoviesDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Language { get; set; }
       // public string ImagePath { get; set; }


    }
}