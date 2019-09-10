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
    public class TrafficSignsController : Controller
    {
        private GPSNavigationSystemContext db = new GPSNavigationSystemContext();
        public int PageSize = 10;  // ten items per page

        public PartialViewResult Menu()
        {
            return PartialView();
        }

        // GET: TrafficSigns
        public ActionResult Index(string searchString, int page = 1)
        {
            Session["searchString"] = null;
            if (!String.IsNullOrEmpty(searchString))
            {
                Session["searchString"] = searchString;
                TrafficSignViewModel model = new TrafficSignViewModel
                {
                    TrafficSigns = db.TrafficSigns
                    .OrderBy(d => d.TrafficSignName)
                    .Where(c => c.TrafficSignName.Contains(searchString))
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = db.TrafficSigns.Where(c => c.TrafficSignName.Contains(searchString)).Count()
                    }
                };
                return View(model);
            }
            else
            {
                TrafficSignViewModel model = new TrafficSignViewModel
                {
                    TrafficSigns = db.TrafficSigns
                   .OrderBy(d => d.TrafficSignName)
                   .Skip((page - 1) * PageSize)
                   .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = db.TrafficSigns.Count()
                    }
                };
                return View(model);
            }
        }

        // GET: TrafficSigns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrafficSign trafficSign = db.TrafficSigns.Find(id);
            if (trafficSign == null)
            {
                return HttpNotFound();
            }
            return View(trafficSign);
        }

        // GET: TrafficSigns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrafficSigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrafficSignID,TrafficSignName")] TrafficSign trafficSign)
        {
            if (ModelState.IsValid)
            {
                db.TrafficSigns.Add(trafficSign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trafficSign);
        }

        // GET: TrafficSigns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrafficSign trafficSign = db.TrafficSigns.Find(id);
            if (trafficSign == null)
            {
                return HttpNotFound();
            }
            return View(trafficSign);
        }

        // POST: TrafficSigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrafficSignID,TrafficSignName")] TrafficSign trafficSign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trafficSign).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trafficSign);
        }

        // GET: TrafficSigns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrafficSign trafficSign = db.TrafficSigns.Find(id);
            if (trafficSign == null)
            {
                return HttpNotFound();
            }
            return View(trafficSign);
        }

        // POST: TrafficSigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrafficSign trafficSign = db.TrafficSigns.Find(id);
            db.TrafficSigns.Remove(trafficSign);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: TrafficSigns/Add
        public ActionResult Add(string id)
        {
            ViewBag.TrafficSignID = new SelectList(db.TrafficSigns.OrderBy(ts => ts.TrafficSignName).Where(ts => ts.TrafficSignName.Equals(id)), "TrafficSignID", "TrafficSignName");
            return View();
        }

        // POST: TrafficSigns/Add
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "TrafficSignLocationID,TrafficSignID,TSLocationStartLatitude,TSLocationStartLongitude,TSLocationEndLatitude,TSLocationEndLongitude")] TrafficSignLocation trafficSignLocation)
        {
            if (ModelState.IsValid)
            {
                db.TrafficSignLocations.Add(trafficSignLocation);
                db.SaveChanges();
                return RedirectToAction("Add");
            }

            ViewBag.TrafficSignID = new SelectList(db.TrafficSigns, "TrafficSignID", "TrafficSignName", trafficSignLocation.TrafficSignID);
            return View(trafficSignLocation);
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
