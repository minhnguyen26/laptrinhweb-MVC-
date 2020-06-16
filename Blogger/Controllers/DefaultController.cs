using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blogger.Models;
namespace Blogger.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        BlogTravelEntities1 _db = new BlogTravelEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getasia()
        {
            
            ViewBag.meta = "dia-diem";
            var v = from t in _db.asias
                    where t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }
        public ActionResult getcountry(long id)
        {
            ViewBag.meta = "dia-diem";
            var v = from t in _db.Countries
                    where t.hide == true && t.asiaId == id
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }
        public ActionResult geteu()
        {

            ViewBag.meta = "dia-diemeu";
            var v = from t in _db.EURs
                    where t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }
        public ActionResult getcountryEU(long id)
        {
            ViewBag.meta = "dia-diemeu";
            var v = from t in _db.CountryEurus
                    where t.hide == true && t.EuId == id
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }

    }
}