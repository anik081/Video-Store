using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Video_Store.Models.Data
{
    [Table("Genre")]
    public class GenreDTO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Slug { get; set; }
        public int Sorting { get; set; }

    }
}