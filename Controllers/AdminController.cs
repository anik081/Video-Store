using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Video_Store.Models.Data;
using Video_Store.Models.View_Model;
using System.IO;
using Video_Store.Models;
using System.Data.Entity;

namespace Video_Store.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            List<MoviesVM> MovieList;
            using (Db db = new Db())
            {
              //  ViewBag.Category = new SelectList(db.Category, "Id", "Name");

                MovieList = db.Movie.ToArray().OrderBy(x => x.Id).Select(x => new MoviesVM(x)).ToList();
            }
            return View(MovieList);
        }
        [HttpGet]
        public ActionResult AddMovie()
        {
            using(Db db = new Db())
            {
                //Category category = new Category();
                VideoStoreEntities videoStoreEntities = new VideoStoreEntities();
                Genremodel genremodel = new Genremodel();
                var getgen = genremodel.Genres.ToList();
                var getcat = videoStoreEntities.Categories.ToList();
                SelectList list = new SelectList(getcat, "Name", "Name");
                SelectList list1 = new SelectList(getgen,  "Name", "Name");
                ViewBag.Category = list;
                ViewBag.Genre = list1;
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddMovie(MoviesVM model)
        {
            MoviesDTO dto = new MoviesDTO();

            

            using (Db db = new Db())
            {
                ViewBag.Category = new SelectList(db.Category, "Id", "Name");

                dto.Name = model.Name;
                if(db.Movie.Any(x=> x.Name == model.Name))
                {
                    ModelState.AddModelError("", "The title already taken");
                    return View(model);
                }
                string yr = model.Year.ToString();
                if (string.IsNullOrWhiteSpace(model.Name) || string.IsNullOrWhiteSpace(model.Language) || string.IsNullOrWhiteSpace(model.Category)|| string.IsNullOrWhiteSpace(model.Genre)||string.IsNullOrWhiteSpace(yr))
                {

                    ModelState.AddModelError("", "All fields required");
                    return View(model);
                   
                }
                dto.Category = model.Category;
                dto.Genre = model.Genre;
                dto.Year = model.Year;
                dto.Language = model.Language;
                db.Movie.Add(dto);
                db.SaveChanges();
                  
               

                //temp data
                TempData["SM"] = "Movie Added!";
               
            }

            return RedirectToAction("Index");
        }
     
        // GET: Admin/Category
        public ActionResult Category()
        {
            //declare list
            List<CatgoryVM> CateogryList;
            using (Db db = new Db()) {
                //init list
                CateogryList = db.Category.ToArray().OrderBy(x => x.Sorting).Select(x => new CatgoryVM(x)).ToList();

            }
            //return view with list
            return View(CateogryList);
        }
        // GET: Admin/Category/AddCategory
        [HttpGet]
        public ActionResult AddCategory()
        {

            return View();
        }
        // POST: Admin/Category/AddCategory

        [HttpPost]
        public ActionResult AddCategory(CatgoryVM model)
        {//check model
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (Db db = new Db())
            {
                //declare slug
                string slug;
                //init dto
                CategoryDTO dto = new CategoryDTO();

                //dto title
                dto.Name = model.Name;
                //check slug
                if (string.IsNullOrWhiteSpace(model.Slug))
                {
                    slug = model.Name.Replace(" ", "-").ToLower();
                }
                else
                {
                    slug = model.Slug.Replace(" ", "-").ToLower();
                }
                //slug and name unique
                if (db.Category.Any(x => x.Name == model.Name) || db.Category.Any(x => x.Slug == model.Slug))
                {
                    ModelState.AddModelError("","The title or slug already taken");
                    return View(model);
                }
                //dto rest
                dto.Slug = slug;
                dto.Sorting = 100;
                //save
                db.Category.Add(dto);
                db.SaveChanges();
                //temp data
                TempData["SM"] = "Category Added!";
            }
            return RedirectToAction("AddCategory");
        }
        // GET: Admin/Genre

        public ActionResult Genre()
        {

            //declare list
            List<GenreVM> GenreList;
           
            using (Db db = new Db())
            {
                //init list
                GenreList = db.Genre.ToArray().OrderBy(x => x.Sorting).Select(x => new GenreVM(x)).ToList();

            }
            //return view with list
            return View(GenreList);
        }
        // GET: Admin/Genre/AddGenre
        [HttpGet]
        public ActionResult AddGenre()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult AddGenre(GenreVM model)
        {//check model
           
            using (Db db = new Db())
            {
                //declare slug
                string slug;
                //init dto
                GenreDTO dto = new GenreDTO();
                //dto title
                dto.Name = model.Name;
                //check slug
                if (string.IsNullOrWhiteSpace(model.Slug))
                {
                    slug = model.Name.Replace(" ", "-").ToLower();
                }
                else
                {
                    slug = model.Slug.Replace(" ", "-").ToLower();
                }
                //slug and name unique
                if (db.Genre.Any(x => x.Name == model.Name) || db.Genre.Any(x => x.Slug == model.Slug))
                {
                    ModelState.AddModelError("", "The title or slug already taken");
                    return View(model);
                }
                //dto rest
                dto.Slug = slug;
                dto.Sorting = 100;
                //save
                db.Genre.Add(dto);
                db.SaveChanges();
                //temp data
                TempData["SM"] = "Language Added!";
            }
            return RedirectToAction("AddGenre");
        }

        [HttpGet]
        public ActionResult DeleteCategory(int id)
        {
            using(Db db = new Db())
            {
                CategoryDTO dto = db.Category.Find(id);
                db.Category.Remove(dto);
                db.SaveChanges();
            }
            return RedirectToAction("Category");
        }
        [HttpGet]
        public ActionResult DeleteMovie(int id)
        {
            using (Db db = new Db())
            {
                MoviesDTO dto = db.Movie.Find(id);
                db.Movie.Remove(dto);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeleteGenre(int id)
        {
            using (Db db = new Db())
            {
                GenreDTO dto = db.Genre.Find(id);
                db.Genre.Remove(dto);
               
                db.SaveChanges();
            }
            return RedirectToAction("Genre");
        }
        [HttpGet]
        public ActionResult EditMovie(int id)
        {
            moviesall mvall = new moviesall();
            Movy movie = mvall.Movies.Single(x => x.Id == id);
            return View(movie);
        }
        [HttpPost]
        public ActionResult EditMovie(Movy model)
        {
            //MoviesDTO dto = new MoviesDTO();
            Movy dto = new Movy();


            using (moviesall db = new moviesall())
            {
                 
                //  ViewBag.Category = new SelectList(db.Category, "Id", "Name");
                
              
                 if (db.Movies.Count(x => x.Name == model.Name)>1)
                {
                    ModelState.AddModelError("", "The title already taken");
                    return View(model);
                }
                string yr = model.Year.ToString();
                if (string.IsNullOrWhiteSpace(model.Name) || string.IsNullOrWhiteSpace(model.Language) || string.IsNullOrWhiteSpace(model.Category) || string.IsNullOrWhiteSpace(model.Genre) || string.IsNullOrWhiteSpace(yr))
                {

                    ModelState.AddModelError("", "All fields required");
                    return View(model);

                }
                moviesall mvall = new moviesall();
                // mvall.Movies(model) = EntityState.Modified;
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();



                //temp data
                TempData["SM"] = "Movie Edited!";

            }

            return RedirectToAction("Index");
        }


    }
}