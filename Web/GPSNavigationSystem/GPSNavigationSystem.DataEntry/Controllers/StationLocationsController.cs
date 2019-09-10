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
    public class StationLocationsController : Controller
    {
        private GPSNavigationSystemContext db = new GPSNavigationSystemContext();
        public int PageSize = 10;  // ten items per page

        // GET: StationLocations
        public ActionResult Index(string type,string searchString, int page = 1)
        {
            Session["searchString"] = null;
            Session["type"] = null;
            if (!string.IsNullOrEmpty(type))
            {
                Session["type"] = type;
                StationLocationViewModel model = new StationLocationViewModel
                {
                    StationLocations = db.StationLocations
                .OrderBy(d => d.StationName)
                .Where(s => s.StationType.Equals(type))
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = db.StationLocations.Where(s => s.StationType.Equals(type)).Count()
                    }
                };
                
                return View(model);
            }else if (!string.IsNullOrEmpty(searchString))
            {
                Session["searchString"] = searchString;
                StationLocationViewModel model = new StationLocationViewModel
                {
                    StationLocations = db.StationLocations
                .OrderBy(d => d.StationName)
                .Where(s => s.StationType.Equals(searchString) || s.StationName.Contains(searchString))
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = db.StationLocations.Where(s => s.StationType.Equals(searchString) || s.StationName.Contains(searchString)).Count()
                    }
                };

                return View(model);
            }
            else
            {
                StationLocationViewModel model = new StationLocationViewModel
                {
                    StationLocations = db.StationLocations
                .OrderBy(d => d.StationName)
                .Skip((page - 1) * PageSize)
                .Take(PageSize).ToList(),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = db.StationLocations.Count()
                    }
                };

                return View(model);
            }
            

        }

        // GET: StationLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationLocation stationLocation = db.StationLocations.Find(id);
            if (stationLocation == null)
            {
                return HttpNotFound();
            }
            return View(stationLocation);
        }

        // GET: StationLocations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StationLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StationLocationID,StationType,StationName,StationLatitude,StationLongitude")] StationLocation stationLocation)
        {
            if (ModelState.IsValid)
            {
                db.StationLocations.Add(stationLocation);
                db.SaveChanges();
                TempData["Success"] = "Successfully Added.";
                return RedirectToAction("Create");
            }

            return View(stationLocation);
        }

        // GET: StationLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationLocation stationLocation = db.StationLocations.Find(id);
            if (stationLocation == null)
            {
                return HttpNotFound();
            }
            return View(stationLocation);
        }

        // POST: StationLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StationLocationID,StationType,StationName,StationLatitude,StationLongitude")] StationLocation stationLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stationLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stationLocation);
        }

        // GET: StationLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationLocation stationLocation = db.StationLocations.Find(id);
            if (stationLocation == null)
            {
                return HttpNotFound();
            }
            return View(stationLocation);
        }

        // POST: StationLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StationLocation stationLocation = db.StationLocations.Find(id);
            db.StationLocations.Remove(stationLocation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




        // GET: StationLocations/Add
        public ActionResult Add(string id)
        {
            PopulateDestinationDropDownList();
            PopulateStationDropDownList(id);
            return View();
        }

        private void PopulateDestinationDropDownList()
        {
            var destinationsQuery = from d in db.Destinations
                                    orderby d.DestinationName
                                    select d;
            ViewBag.DestinationID = new SelectList(destinationsQuery, "DestinationID", "DestinationName");
        }

        private void PopulateStationDropDownList(string id)
        {
            var stationsQuery = from d in db.StationLocations
                                orderby d.StationName
                                where d.StationName.Equals(id)
                                select d;
            
            ViewBag.StationLocationID = new SelectList(stationsQuery, "StationLocationID", "StationName");

        }



        // POST: StationLocations/Add
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "StationDestinationID,StationLocationID,DestinationID")] StationDestination stationDestination)
        {
            if (ModelState.IsValid)
            {
                db.StationDestinations.Add(stationDestination);
                db.SaveChanges();
                TempData["Success"] = "Successfully Added.";
                return RedirectToAction("Add");
            }

            ViewBag.DestinationID = new SelectList(db.Destinations, "DestinationID", "DestinationName", stationDestination.DestinationID);
            ViewBag.StationLocationID = new SelectList(db.StationLocations, "StationLocationID", "StationName", stationDestination.StationLocationID);
            return View(stationDestination);
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
