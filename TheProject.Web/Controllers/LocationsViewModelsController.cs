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
    public class LocationsViewModelsController : Controller
    {
        private TheProjectDbContext db = new TheProjectDbContext();

        // GET: LocationsViewModels
        public ActionResult Index()
        {
            return View(db.Locations.ToList());
        }

        // GET: LocationsViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationsViewModel locationsViewModel = db.Locations.Find(id);
            if (locationsViewModel == null)
            {
                return HttpNotFound();
            }
            return View(locationsViewModel);
        }

        // GET: LocationsViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LocationsViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ZipCode,StreetName,StreetNum,Extra,CityId,CityName,CreatedTime,UpdatedTime")] LocationsViewModel locationsViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Locations.Add(LocationsViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(locationsViewModel);
        }

        // GET: LocationsViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationsViewModel locationsViewModel = db.LocationsViewModels.Find(id);
            if (locationsViewModel == null)
            {
                return HttpNotFound();
            }
            return View(locationsViewModel);
        }

        // POST: LocationsViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ZipCode,StreetName,StreetNum,Extra,CityId,CityName,CreatedTime,UpdatedTime")] LocationsViewModel locationsViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locationsViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(locationsViewModel);
        }

        // GET: LocationsViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationsViewModel locationsViewModel = db.Locations.Find(id);
            if (locationsViewModel == null)
            {
                return HttpNotFound();
            }
            return View(locationsViewModel);
        }

        // POST: LocationsViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LocationsViewModel locationsViewModel = DB.Locations.Find(id);
            db.Locations.Remove(Locations);
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
