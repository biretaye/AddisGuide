using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GPSNavigationSystem.Domain.DAL;
using GPSNavigationSystem.Domain.Entities;
using GPSNavigationSystem.DataEntry.Models;

namespace GPSNavigationSystem.DataEntry.Controllers
{
    public class TrafficSignLocationsController : Controller
    {
        private GPSNavigationSystemContext db = new GPSNavigationSystemContext();
        public int PageSize = 10;

        // GET: TrafficSignLocations
        public ActionResult Index(int page =1)
        {
            TrafficSignLocationViewModel model = new TrafficSignLocationViewModel
            {
                TrafficSignLocations = db.TrafficSignLocations
                .Include(s => s.TrafficSign)
                .OrderBy(s => s.TrafficSign.TrafficSignName)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = db.TrafficSignLocations.Count()
                }
            };



            return View(model);
        }

        // GET: TrafficSignLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrafficSignLocation trafficSignLocation = db.TrafficSignLocations.Find(id);
            if (trafficSignLocation == null)
            {
                return HttpNotFound();
            }
            return View(trafficSignLocation);
        }

        // GET: TrafficSignLocations/Create
        public ActionResult Create()
        {
            ViewBag.TrafficSignID = new SelectList(db.TrafficSigns.OrderBy(ts => ts.TrafficSignName), "TrafficSignID", "TrafficSignName");
            return View();
        }

        // POST: TrafficSignLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrafficSignLocationID,TrafficSignID,TSLocationStartLatitude,TSLocationStartLongitude,TSLocationEndLatitude,TSLocationEndLongitude")] TrafficSignLocation trafficSignLocation)
        {
            if (ModelState.IsValid)
            {
                db.TrafficSignLocations.Add(trafficSignLocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TrafficSignID = new SelectList(db.TrafficSigns, "TrafficSignID", "TrafficSignName", trafficSignLocation.TrafficSignID);
            return View(trafficSignLocation);
        }

        // GET: TrafficSignLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrafficSignLocation trafficSignLocation = db.TrafficSignLocations.Find(id);
            if (trafficSignLocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.TrafficSignID = new SelectList(db.TrafficSigns.OrderBy(ts => ts.TrafficSignName), "TrafficSignID", "TrafficSignName", trafficSignLocation.TrafficSignID);
            return View(trafficSignLocation);
        }

        // POST: TrafficSignLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrafficSignLocationID,TrafficSignID,TSLocationStartLatitude,TSLocationStartLongitude,TSLocationEndLatitude,TSLocationEndLongitude")] TrafficSignLocation trafficSignLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trafficSignLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TrafficSignID = new SelectList(db.TrafficSigns, "TrafficSignID", "TrafficSignName", trafficSignLocation.TrafficSignID);
            return View(trafficSignLocation);
        }

        // GET: TrafficSignLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrafficSignLocation trafficSignLocation = db.TrafficSignLocations.Find(id);
            if (trafficSignLocation == null)
            {
                return HttpNotFound();
            }
            return View(trafficSignLocation);
        }

        // POST: TrafficSignLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrafficSignLocation trafficSignLocation = db.TrafficSignLocations.Find(id);
            db.TrafficSignLocations.Remove(trafficSignLocation);
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
