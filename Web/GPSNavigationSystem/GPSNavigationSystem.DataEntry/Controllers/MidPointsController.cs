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

namespace GPSNavigationSystem.DataEntry.Controllers
{
    public class MidPointsController : Controller
    {
        private GPSNavigationSystemContext db = new GPSNavigationSystemContext();

        // GET: MidPoints
        public ActionResult Index()
        {
            return View(db.MidPoints.ToList());
        }

        // GET: MidPoints/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MidPoint midPoint = db.MidPoints.Find(id);
            if (midPoint == null)
            {
                return HttpNotFound();
            }
            return View(midPoint);
        }

        // GET: MidPoints/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MidPoints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MidPointID,MidPointName,MidPointLatitude,MidPointLongitude")] MidPoint midPoint)
        {
            if (ModelState.IsValid)
            {
                db.MidPoints.Add(midPoint);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(midPoint);
        }

        // GET: MidPoints/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MidPoint midPoint = db.MidPoints.Find(id);
            if (midPoint == null)
            {
                return HttpNotFound();
            }
            return View(midPoint);
        }

        // POST: MidPoints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MidPointID,MidPointName,MidPointLatitude,MidPointLongitude")] MidPoint midPoint)
        {
            if (ModelState.IsValid)
            {
                db.Entry(midPoint).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(midPoint);
        }

        // GET: MidPoints/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MidPoint midPoint = db.MidPoints.Find(id);
            if (midPoint == null)
            {
                return HttpNotFound();
            }
            return View(midPoint);
        }

        // POST: MidPoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MidPoint midPoint = db.MidPoints.Find(id);
            db.MidPoints.Remove(midPoint);
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
