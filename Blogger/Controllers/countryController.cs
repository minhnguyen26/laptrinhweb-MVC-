using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blogger.Models;

namespace Blogger.Controllers
{
    public class countryController : Controller
    {
        // GET: country
        BlogTravelEntities1 _db = new BlogTravelEntities1();
        public ActionResult Index(string meta)
        {
            var v = from t in _db.asias
                    where t.meta == meta
                    select t;
            return View(v.FirstOrDefault());
        }
        public ActionResult Detail(long id)
        {
            var v = from t in _db.Countries 
                    where t.id == id
                    select t;
            return View(v.FirstOrDefault());
        }
    }
}