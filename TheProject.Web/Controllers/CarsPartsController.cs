using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheProject.DB.Entities;
using TheProject.DataAccess;

namespace TheProject.Web.Controllers
{
    public class CarsPartsController : Controller
    {
        private TheProjectDbContext db = new TheProjectDbContext();

        // GET: CarsParts
        public ActionResult Index()
        {
            var carsParts = db.CarsParts.Include(c => c.Location);
            return View(carsParts.ToList());
        }

        // GET: CarsParts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarsParts carsParts = db.CarsParts.Find(id);
            if (carsParts == null)
            {
                return HttpNotFound();
            }
            return View(carsParts);
        }

        // GET: CarsParts/Create
        public ActionResult Create()
        {
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "ZipCode");
            return View();
        }

        // POST: CarsParts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,About,Price,inStoke,Order,LocationId,CreatedTime,UpdatedTime")] CarsParts carsParts)
        {
            if (ModelState.IsValid)
            {
                db.CarsParts.Add(carsParts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocationId = new SelectList(db.Locations, "Id", "ZipCode", carsParts.LocationId);
            return View(carsParts);
        }

        // GET: CarsParts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarsParts carsParts = db.CarsParts.Find(id);
            if (carsParts == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "ZipCode", carsParts.LocationId);
            return View(carsParts);
        }

        // POST: CarsParts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,About,Price,inStoke,Order,LocationId,CreatedTime,UpdatedTime")] CarsParts carsParts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carsParts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "ZipCode", carsParts.LocationId);
            return View(carsParts);
        }

        // GET: CarsParts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarsParts carsParts = db.CarsParts.Find(id);
            if (carsParts == null)
            {
                return HttpNotFound();
            }
            return View(carsParts);
        }

        // POST: CarsParts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarsParts carsParts = db.CarsParts.Find(id);
            db.CarsParts.Remove(carsParts);
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
