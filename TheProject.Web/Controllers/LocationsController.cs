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
using TheProject.Web.Models;

namespace TheProject.Web.Controllers
{
    public class LocationsController : Controller
    {
        private TheProjectDbContext db = new TheProjectDbContext();

        private readonly UnitOfWork uow;

        public LocationsController()
        {
            uow = new UnitOfWork(new TheProjectDbContext());
        }

        public LocationsController(TheProjectDbContext context)
        {
            uow = new UnitOfWork(context);
        }

        // GET: Locations
        public ActionResult Index()
        {
            IEnumerable<Location> location = uow.LocationRepository.GetAll();

            List<LocationsViewModel> locations = new List<LocationsViewModel>();

            foreach(Location l in location)
            {
                LocationsViewModel model = new LocationsViewModel(l);
                locations.Add(model);
            }

            return View();
        }

        // GET: Locations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = uow.LocationRepository.GetByID((int)id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // GET: Locations/Create
        public ActionResult Create()
        {
            IEnumerable<City> cities = uow.CityRepository.GetAll();
            List<CityViewModel> model = new List<CityViewModel>();
            foreach (City city in cities)
            {
                CityViewModel c = new CityViewModel(city);
                model.Add(c);
            }

            ViewBag.CityId = new SelectList(uow.CityRepository, "Id", "Name");
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ZipCode,StreetName,StreetNum,Extra,CityId,CreatedTime,UpdatedTime")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.Locations.Add(location);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", location.CityId);
            return View(location);
        }

        // GET: Locations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", location.CityId);
            return View(location);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ZipCode,StreetName,StreetNum,Extra,CityId,CreatedTime,UpdatedTime")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.Entry(location).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", location.CityId);
            return View(location);
        }

        // GET: Locations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Location location = db.Locations.Find(id);
            db.Locations.Remove(location);
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
