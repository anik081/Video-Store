using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Video_Store.Models.Data;

namespace Video_Store.Models.View_Model
{
    public class MoviesVM
    {
        public MoviesVM()
        {

        }
        public MoviesVM(MoviesDTO model)
        {
            Id = model.Id;
            Name = model.Name;
            Category = model.Category;
            Genre = model.Genre;
            Year = model.Year;
            Language = model.Language;
          //  ImagePath = model.ImagePath;

        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public int Year { get; set; }
      //  [Required]
        public string Language { get; set; }
        //[DisplayName("Upload File")]
      //  public string ImagePath { get; set; }

      //  public HttpPostedFileBase ImageFile { get; set; }
    }
}