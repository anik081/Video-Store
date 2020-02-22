using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Video_Store.Models.Data;

namespace Video_Store.Models.View_Model
{
    public class CatgoryVM
    {
        public CatgoryVM()
        {

        }
        public CatgoryVM(CategoryDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Slug = dto.Slug;
            Sorting = dto.Sorting;

        }
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        public string Slug { get; set; }
        public int Sorting { get; set; }

    }
}