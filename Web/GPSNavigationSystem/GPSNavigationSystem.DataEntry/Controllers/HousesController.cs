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
    public class HousesController : Controller
    {
        private GPSNavigationSystemContext db = new GPSNavigationSystemContext();
        public int PageSize = 10;  // ten items per page

        // GET: Houses
        public ActionResult Index(string searchString, string searchString2, int page = 1)
        {
            Session["ss1"] = null;
            Session["ss2"] = null;
            if (!String.IsNullOrEmpty(searchString) && !String.IsNullOrEmpty(searchString2))
            {
                Session["ss1"] = searchString;
                Session["ss2"] = searchString2;
                HouseViewModel model = new HouseViewModel
                {
                    Houses = db.Houses
                    //.Include(h => h.Destination)
                    .Include(h => h.Street)
                    .OrderBy(d => d.Street.StreetName).ThenBy(d => d.HouseNumber)
                    .Where(c => c.HouseNumber.Contains(searchString) && c.Street.StreetName.Contains(searchString2))
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = db.Houses.Where(c => c.HouseNumber.Contains(searchString) && c.Street.StreetName.Contains(searchString2)).Count()
                    }
                };
                return View(model);
            }
            else if (!String.IsNullOrEmpty(searchString))
            {
                Session["ss1"] = searchString;
                HouseViewModel model = new HouseViewModel
                {
                    Houses = db.Houses
                    //.Include(h => h.Destination)
                    .Include(h => h.Street)
                    .OrderBy(d => d.Street.StreetName).ThenBy(d => d.HouseNumber)
                    .Where(c => c.HouseNumber.Contains(searchString) )
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = db.Houses.Where(c => c.HouseNumber.Contains(searchString)).Count()
                    }
                };
                return View(model);
            }
            else if (!String.IsNullOrEmpty(searchString2))
            {
                Session["ss2"] = searchString2;
                HouseViewModel model = new HouseViewModel
                {
                    Houses = db.Houses
                    //.Include(h => h.Destination)
                    .Include(h => h.Street)
                    .OrderBy(d => d.Street.StreetName).ThenBy(d => d.HouseNumber)
                    .Where(c =>  c.Street.StreetName.Contains(searchString2))
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = db.Houses.Where(c => c.Street.StreetName.Contains(searchString2)).Count()
                    }
                };
                return View(model);
            }
            else
            {
                HouseViewModel model = new HouseViewModel
                {
                    Houses = db.Houses
                    .OrderBy(d => d.Street.StreetName).ThenBy(d => d.HouseNumber)
                    //.Include(h => h.Destination)
                    .Include(h => h.Street)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = db.Houses.Count()
                    }
                };
                return View(model);
            }
        }

        // GET: Houses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.Houses.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            return View(house);
        }

        // GET: Houses/Create
        public ActionResult Create()
        {
            //ViewBag.DestinationID = new SelectList(db.Destinations.OrderBy(d => d.DestinationName), "DestinationID", "DestinationName");
            ViewBag.StreetID = new SelectList(db.Street.OrderBy(s => s.StreetName), "StreetID", "StreetName");
            return View();
        }

        // POST: Houses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HouseID,HouseNumber,StreetID,House_Latitude,House_Longitude")] House house)
        {
            if (ModelState.IsValid)
            {
                db.Houses.Add(house);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.DestinationID = new SelectList(db.Destinations, "DestinationID", "DestinationName", house.DestinationID);
            ViewBag.StreetID = new SelectList(db.Street, "StreetID", "StreetName", house.StreetID);
            return View(house);
        }

        // GET: Houses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.Houses.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            //ViewBag.DestinationID = new SelectList(db.Destinations.OrderBy(d => d.DestinationName), "DestinationID", "DestinationName", house.DestinationID);
            ViewBag.StreetID = new SelectList(db.Street.OrderBy(s => s.StreetName), "StreetID", "StreetName", house.StreetID);
            return View(house);
        }

        // POST: Houses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HouseID,HouseNumber,StreetID,House_Latitude,House_Longitude")] House house)
        {
            if (ModelState.IsValid)
            {
                db.Entry(house).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.DestinationID = new SelectList(db.Destinations, "DestinationID", "DestinationName", house.DestinationID);
            ViewBag.StreetID = new SelectList(db.Street, "StreetID", "StreetName", house.StreetID);
            return View(house);
        }

        // GET: Houses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.Houses.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            return View(house);
        }

        // POST: Houses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            House house = db.Houses.Find(id);
            db.Houses.Remove(house);
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
