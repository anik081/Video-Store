using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Video_Store.Models;

namespace Video_Store.Models.Data
{
    public class Db: DbContext
    {
        public DbSet<CategoryDTO> Category { get; set; }
        public DbSet<GenreDTO> Genre { get; set; }
        public DbSet<MoviesDTO> Movie { get; set; }
        
       
    }
}