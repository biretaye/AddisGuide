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
    public class ServiceProviderLocationsController : Controller
    {
        private GPSNavigationSystemContext db = new GPSNavigationSystemContext();
        public int PageSize = 10;  // 10 items per page

        // GET: ServiceProviderLocations
        public ActionResult Index(int page = 1)
        {

            ServiceProviderLocationViewModel model = new ServiceProviderLocationViewModel
            {
                ServiceProviderLocations = db.ServiceProviderLocations
                //.Include(s => s.Destination)
                .Include(s => s.ServiceProvider)
                .OrderBy(s => s.ServiceProvider.ServiceProviderName)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = db.ServiceProviderLocations.Count()
                }
            };
            return View(model);
        }

        // GET: ServiceProviderLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceProviderLocation serviceProviderLocation = db.ServiceProviderLocations.Find(id);
            if (serviceProviderLocation == null)
            {
                return HttpNotFound();
            }
            return View(serviceProviderLocation);
        }

        // GET: ServiceProviderLocations/Create
        public ActionResult Create()
        {
            //ViewBag.DestinationID = new SelectList(db.Destinations.OrderBy(d => d.DestinationName), "DestinationID", "DestinationName");
            ViewBag.ServiceProviderID = new SelectList(db.ServiceProviders.OrderBy(d => d.ServiceProviderName), "ServiceProviderID", "ServiceProviderName");
            return View();
        }

        // POST: ServiceProviderLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServiceProviderLocationID,ServiceProviderID,ServiceProviderLatitude,ServiceProviderLongitude")] ServiceProviderLocation serviceProviderLocation)
        {
            if (ModelState.IsValid)
            {
                db.ServiceProviderLocations.Add(serviceProviderLocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.DestinationID = new SelectList(db.Destinations, "DestinationID", "DestinationName", serviceProviderLocation.DestinationID);
            ViewBag.ServiceProviderID = new SelectList(db.ServiceProviders, "ServiceProviderID", "ServiceProviderName", serviceProviderLocation.ServiceProviderID);
            return View(serviceProviderLocation);
        }

        // GET: ServiceProviderLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceProviderLocation serviceProviderLocation = db.ServiceProviderLocations.Find(id);
            if (serviceProviderLocation == null)
            {
                return HttpNotFound();
            }
            //ViewBag.DestinationID = new SelectList(db.Destinations.OrderBy(d => d.DestinationName), "DestinationID", "DestinationName", serviceProviderLocation.DestinationID);
            ViewBag.ServiceProviderID = new SelectList(db.ServiceProviders.OrderBy(d => d.ServiceProviderName), "ServiceProviderID", "ServiceProviderName", serviceProviderLocation.ServiceProviderID);
            return View(serviceProviderLocation);
        }

        // POST: ServiceProviderLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServiceProviderLocationID,ServiceProviderID,ServiceProviderLatitude,ServiceProviderLongitude")] ServiceProviderLocation serviceProviderLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceProviderLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.DestinationID = new SelectList(db.Destinations, "DestinationID", "DestinationName", serviceProviderLocation.DestinationID);
            ViewBag.ServiceProviderID = new SelectList(db.ServiceProviders, "ServiceProviderID", "ServiceProviderName", serviceProviderLocation.ServiceProviderID);
            return View(serviceProviderLocation);
        }

        // GET: ServiceProviderLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceProviderLocation serviceProviderLocation = db.ServiceProviderLocations.Find(id);
            if (serviceProviderLocation == null)
            {
                return HttpNotFound();
            }
            return View(serviceProviderLocation);
        }

        // POST: ServiceProviderLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceProviderLocation serviceProviderLocation = db.ServiceProviderLocations.Find(id);
            db.ServiceProviderLocations.Remove(serviceProviderLocation);
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
