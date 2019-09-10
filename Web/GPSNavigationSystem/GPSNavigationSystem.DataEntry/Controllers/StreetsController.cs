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
    public class StreetsController : Controller
    {
        private GPSNavigationSystemContext db = new GPSNavigationSystemContext();
        public int PageSize = 10;  // ten items per page

        public PartialViewResult Menu()
        {
            return PartialView();
        }

        // GET: Streets
        public ActionResult Index(string searchString, int page = 1)
        {
            Session["searchString"] = null;
            if (!String.IsNullOrEmpty(searchString))
            {
                Session["searchString"] = searchString;
                StreetViewModel model = new StreetViewModel
                {
                    Streets = db.Street
                    .OrderBy(d => d.StreetName)
                    .Where(c => c.StreetName.Contains(searchString))
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = db.Street.Where(c => c.StreetName.Contains(searchString)).Count()
                    }
                };
                return View(model);
            }
            else
            {
                StreetViewModel model = new StreetViewModel
                {
                    Streets = db.Street
                    .OrderBy(d => d.StreetName)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = db.Street.Count()
                    }
                };
                return View(model);
            }
        }

        // GET: Streets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Street street = db.Street.Find(id);
            if (street == null)
            {
                return HttpNotFound();
            }
            return View(street);
        }

        // GET: Streets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Streets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StreetID,StreetName,StreetStartLatitude,StreetStartLongitude,StreetEndLatitude,StreetEndLongitude")] Street street)
        {
            if (ModelState.IsValid)
            {
                db.Street.Add(street);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(street);
        }

        // GET: Streets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Street street = db.Street.Find(id);
            if (street == null)
            {
                return HttpNotFound();
            }
            return View(street);
        }

        // POST: Streets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StreetID,StreetName,StreetStartLatitude,StreetStartLongitude,StreetEndLatitude,StreetEndLongitude")] Street street)
        {
            if (ModelState.IsValid)
            {
                db.Entry(street).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(street);
        }

        // GET: Streets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Street street = db.Street.Find(id);
            if (street == null)
            {
                return HttpNotFound();
            }
            return View(street);
        }

        // POST: Streets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Street street = db.Street.Find(id);
            db.Street.Remove(street);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Houses/Add
        public ActionResult Add(string id)
        {
            //ViewBag.DestinationID = new SelectList(db.Destinations.OrderBy(d => d.DestinationName), "DestinationID", "DestinationName");
            ViewBag.StreetID = new SelectList(db.Street.OrderBy(s => s.StreetName).Where(s => s.StreetName.Equals(id)), "StreetID", "StreetName");
            return View();
        }

        // POST: Houses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "HouseID,HouseNumber,StreetID,House_Latitude,House_Longitude")] House house)
        {
            if (ModelState.IsValid)
            {
                db.Houses.Add(house);
                db.SaveChanges();
                return RedirectToAction("Add");
            }

            //ViewBag.DestinationID = new SelectList(db.Destinations, "DestinationID", "DestinationName", house.DestinationID);
            ViewBag.StreetID = new SelectList(db.Street, "StreetID", "StreetName", house.StreetID);
            return View(house);
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
