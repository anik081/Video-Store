using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Video_Store.Models.Data;
using Video_Store.Models.View_Model;
using System.IO;
using System.Data.Entity;
using Video_Store.Models;

namespace Video_Store.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Home(string SearchBy, string Search)
        {
            moviesall db = new moviesall();

            if (SearchBy == "Name")
            {

                return View(db.Movies.Where(x=>x.Name.StartsWith(Search)||Search==null).ToList());
            }
            else if (SearchBy == "Category")
            {
                return View(db.Movies.Where(x => x.Category == Search || Search == null).ToList());

            }
            else if(SearchBy == "Language")
            {
                return View(db.Movies.Where(x => x.Genre == Search || Search == null).ToList());
            }
            else
            {
                return View(db.Movies.ToList());

            }
        }/// <summary>

         /// </summary>
         /// <returns></returns>

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}