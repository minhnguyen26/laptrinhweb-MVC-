using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blogger.Models;

namespace Blogger.Controllers
{
    public class countryEUController : Controller
    {
        // GET: country
        BlogTravelEntities1 _db = new BlogTravelEntities1();
        public ActionResult Index(string meta)
        {
            var v = from t in _db.EURs
                    where t.meta == meta
                    select t;
            return View(v.FirstOrDefault());
        }
        public ActionResult Detail(long id)
        {
            var v = from t in _db.CountryEurus
                    where t.id == id
                    select t;
            return View(v.FirstOrDefault());
        }
    }
}