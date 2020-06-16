using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blogger.Help;
using Blogger.Models;

namespace Blogger.Areas.admin.Controllers
{
    public class CountryEurusController : Controller
    {
        private BlogTravelEntities1 db = new BlogTravelEntities1();

        // GET: admin/CountryEurus
        public ActionResult Index(long? id = null)
        {
            getEUR(id);
            return View();
        }
        public void getEUR(long? selectedId = null)
        {
            ViewBag.EUR = new SelectList(db.EURs.Where(x => x.hide == true).OrderBy(x => x.order), "id", "name", selectedId);
        }
        public ActionResult getcountryEU(long? id)
        {
            if (id == null)
            {
                var v = db.CountryEurus.OrderBy(x => x.order).ToList();
                return PartialView(v);
            }
            var m = db.CountryEurus.Where(x => x.EuId == id).OrderBy(x => x.order).ToList();
            return PartialView(m);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryEuru countryEuru = db.CountryEurus.Find(id);
            if (countryEuru == null)
            {
                return HttpNotFound();
            }
            return View(countryEuru);
        }
        // GET: admin/CountryEurus/Create
        public ActionResult Create()
        {
            ViewBag.EuId = new SelectList(db.EURs, "id", "name");
            return View();
        }

        // POST: admin/CountryEurus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "id,name,img,description,description1,meta,hide,order,datebigin,asiaId")] CountryEuru countryEuru, HttpPostedFileBase img)
        {
            try
            {
                var path = "";
                var filename = "";
                if (ModelState.IsValid)
                {
                    if (img != null)
                    {
                        filename = DateTime.Now.ToString("dd-MM-yy=hh-mm-ss-") + img.FileName;
                        path = Path.Combine(Server.MapPath("~/Content/images"), filename);
                        img.SaveAs(path);
                        countryEuru.img = filename;
                    }
                    else
                    {
                        countryEuru.img = "hagiang2.jpg";
                    }
                    countryEuru.detebegin = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    countryEuru.meta = Functions.ConvertToUnSign(countryEuru.meta);
                    countryEuru.order = getMaxOrder(countryEuru.EuId);
                    db.CountryEurus.Add(countryEuru);
                    db.SaveChanges();
                    return RedirectToAction("Index", "CountryEurus", new { id = countryEuru.EuId });
                }
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(countryEuru);
        }
        public int getMaxOrder(long? EuId)
        {
            if (EuId == null)
                return 1;
            return db.CountryEurus.Where(x => x.EuId == EuId).Count();
        }
        // GET: admin/Countries/Edit/5

        // GET: admin/CountryEurus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryEuru  countryEuru = db.CountryEurus.Find(id);
            if (countryEuru == null)
            {
                return HttpNotFound();
            }
            getcountryEU(countryEuru.EuId);
            return View(countryEuru);
        }

        // POST: admin/CountryEurus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "id,name,price,img,description,meta,size,color,hide,order,datebegin,categoryid")] CountryEuru countryEuru, HttpPostedFileBase img)
        {
            try
            {
                var path = "";
                var filename = "";
                CountryEuru temp = db.CountryEurus.Find(countryEuru.id);
                if (ModelState.IsValid)
                {
                    if (img != null)
                    {
                        filename = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-") + img.FileName;
                        path = Path.Combine(Server.MapPath("~/Content/img/countryeu"), filename);
                        img.SaveAs(path);
                        temp.img = filename;
                    }
                    temp.name = countryEuru.name;
                    temp.description = countryEuru.description;
                    temp.description1 = countryEuru.description1;
                    temp.meta = Functions.ConvertToUnSign(countryEuru.meta);
                    temp.hide = countryEuru.hide;
                    temp.order = countryEuru.order;
                    db.Entry(temp).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "CountryEurus", new { id = countryEuru.EuId });
                }
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(countryEuru);
        }


        // GET: admin/CountryEurus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryEuru countryEuru = db.CountryEurus.Find(id);
            if (countryEuru == null)
            {
                return HttpNotFound();
            }
            return View(countryEuru);
        }

        // POST: admin/CountryEurus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CountryEuru countryEuru = db.CountryEurus.Find(id);
            db.CountryEurus.Remove(countryEuru);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
