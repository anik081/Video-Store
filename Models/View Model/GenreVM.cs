using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Video_Store.Models.Data;

namespace Video_Store.Models.View_Model
{
    public class GenreVM
    {
        public GenreVM()
        {

        }
        public GenreVM(GenreDTO model)
        {
            Id = model.Id;
            Name = model.Name;
            Slug = model.Slug;
            Sorting = model.Sorting;
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Slug { get; set; }
        public int Sorting { get; set; }

    }
}