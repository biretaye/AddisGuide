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
    public class StationDestinationsController : Controller
    {
        private GPSNavigationSystemContext db = new GPSNavigationSystemContext();
        public int PageSize = 10;  // six items per page

        // GET: StationDestinations
        public ActionResult Index(string searchString, int page = 1 )
        {
            Session["searchString"] = null;
            if (!string.IsNullOrEmpty(searchString))
            {
                Session["searchString"] = searchString;
                StationDestinationViewModel model = new StationDestinationViewModel
                {
                    StationDestinations = db.StationDestinations
                .Include(s => s.Destination)
                .Include(s => s.StationLocation)
                .Include(s => s.MidPoint)
                .Where(s => s.StationLocation.StationName.Contains(searchString) || s.Destination.DestinationName.Contains(searchString))
                .OrderBy(s => s.StationLocation.StationName).ThenBy(d => d.Destination.DestinationName)
                //.GroupBy(s => s.Destination.DestinationName)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = db.StationDestinations.Where(s => s.StationLocation.StationName.Contains(searchString) || s.Destination.DestinationName.Contains(searchString)).Count()
                    }
                };
                return View(model);
            }
            else
            {
                StationDestinationViewModel model = new StationDestinationViewModel
                {
                    StationDestinations = db.StationDestinations
                                .Include(s => s.Destination)
                                .Include(s => s.StationLocation)
                                .Include(s => s.MidPoint)
                                .OrderBy(s => s.StationLocation.StationName).ThenBy(d => d.Destination.DestinationName)
                                //.GroupBy(s => s.Destination.DestinationName)
                                .Skip((page - 1) * PageSize)
                                .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = db.StationDestinations.Count()
                    }
                };
                return View(model);
            }
            
        }

        // GET: StationDestinations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationDestination stationDestination = db.StationDestinations.Find(id);
            if (stationDestination == null)
            {
                return HttpNotFound();
            }
            return View(stationDestination);
        }

        // GET: StationDestinations/Create
        public ActionResult Create(string type, string id)
        {
            //ViewBag.DestinationID = new SelectList(db.Destinations, "DestinationID", "DestinationName");
            //ViewBag.StationLocationID = new SelectList(db.StationLocations, "StationLocationID", "StationName");
            //if (!string.IsNullOrEmpty(type))
            //{

            //}
            PopulateDestinationDropDownList();
            PopulateStationDropDownList(type, id);
            ViewBag.MidPointID = new SelectList(db.MidPoints.OrderBy(mp => mp.MidPointName), "MidPointID", "MidPointName");
            return View();
        }

        private void PopulateDestinationDropDownList()
        {
            var destinationsQuery = from d in db.Destinations
                                    orderby d.DestinationName
                                    select d;
            ViewBag.DestinationID = new SelectList(destinationsQuery, "DestinationID", "DestinationName");
        }

        private void PopulateStationDropDownList(string type, string id)
        {
            var stationsQuery = from d in db.StationLocations
                                   orderby d.StationName
                                 where d.StationType.Equals(type)
                                   select d;
            if (!string.IsNullOrEmpty(id))
            {
                stationsQuery = stationsQuery.Where(s => s.StationName.Equals(id));
            }
                ViewBag.StationLocationID = new SelectList(stationsQuery, "StationLocationID", "StationName");

        }

        

        // POST: StationDestinations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StationDestinationID,StationLocationID,DestinationID,MidPointID")] StationDestination stationDestination)
        {
            if (ModelState.IsValid)
            {
                db.StationDestinations.Add(stationDestination);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DestinationID = new SelectList(db.Destinations, "DestinationID", "DestinationName", stationDestination.DestinationID);
            ViewBag.MidPointID = new SelectList(db.MidPoints, "MidPointID", "MidPointName", stationDestination.MidPointID);
            ViewBag.StationLocationID = new SelectList(db.StationLocations, "StationLocationID", "StationName", stationDestination.StationLocationID);
            return View(stationDestination);
        }

        // GET: StationDestinations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationDestination stationDestination = db.StationDestinations.Find(id);
            if (stationDestination == null)
            {
                return HttpNotFound();
            }
            ViewBag.MidPointID = new SelectList(db.MidPoints, "MidPointID", "MidPointName", stationDestination.MidPointID);
            ViewBag.DestinationID = new SelectList(db.Destinations.OrderBy(s => s.DestinationName), "DestinationID", "DestinationName", stationDestination.DestinationID);
            ViewBag.StationLocationID = new SelectList(db.StationLocations.OrderBy(s => s.StationName), "StationLocationID", "StationName", stationDestination.StationLocationID);
            return View(stationDestination);
        }

        // POST: StationDestinations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StationDestinationID,StationLocationID,DestinationID,MidPointID")] StationDestination stationDestination)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stationDestination).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MidPointID = new SelectList(db.MidPoints, "MidPointID", "MidPointName", stationDestination.MidPointID);
            ViewBag.DestinationID = new SelectList(db.Destinations, "DestinationID", "DestinationName", stationDestination.DestinationID);
            ViewBag.StationLocationID = new SelectList(db.StationLocations, "StationLocationID", "StationName", stationDestination.StationLocationID);
            return View(stationDestination);
        }

        // GET: StationDestinations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationDestination stationDestination = db.StationDestinations.Find(id);
            if (stationDestination == null)
            {
                return HttpNotFound();
            }
            return View(stationDestination);
        }

        // POST: StationDestinations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StationDestination stationDestination = db.StationDestinations.Find(id);
            db.StationDestinations.Remove(stationDestination);
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
