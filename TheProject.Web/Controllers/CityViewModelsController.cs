using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheProject.DataAccess;
using TheProject.Web.Models;

namespace TheProject.Web.Controllers
{
    public class CityViewModelsController : Controller
    {
        private TheProjectDbContext db = new TheProjectDbContext();

        // GET: CityViewModels
        public ActionResult Index()
        {
            return View(db.CityViewModels.ToList());
        }

        // GET: CityViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityViewModel cityViewModel = db.CityViewModels.Find(id);
            if (cityViewModel == null)
            {
                return HttpNotFound();
            }
            return View(cityViewModel);
        }

        // GET: CityViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CityViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CreatedTime,UpdatedTime")] CityViewModel cityViewModel)
        {
            if (ModelState.IsValid)
            {
                db.CityViewModels.Add(cityViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cityViewModel);
        }

        // GET: CityViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityViewModel cityViewModel = db.CityViewModels.Find(id);
            if (cityViewModel == null)
            {
                return HttpNotFound();
            }
            return View(cityViewModel);
        }

        // POST: CityViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CreatedTime,UpdatedTime")] CityViewModel cityViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cityViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cityViewModel);
        }

        // GET: CityViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityViewModel cityViewModel = db.CityViewModels.Find(id);
            if (cityViewModel == null)
            {
                return HttpNotFound();
            }
            return View(cityViewModel);
        }

        // POST: CityViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CityViewModel cityViewModel = db.CityViewModels.Find(id);
            db.CityViewModels.Remove(cityViewModel);
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
