﻿using System;
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
    public class DestinationsController : Controller
    {
        private GPSNavigationSystemContext db = new GPSNavigationSystemContext();
        public int PageSize = 10;  // ten items per page

        public PartialViewResult Menu()
        {
            return PartialView();
        }


        // GET: Destinations
        public ActionResult Index(string searchString, int page = 1)
        {
            Session["searchString"] = null;
            if (!String.IsNullOrEmpty(searchString))
            {
                Session["searchString"] = searchString;
                DestinationViewModel model = new DestinationViewModel
                {
                    Destinations = db.Destinations
                    .Where(d => d.DestinationName.Contains(searchString))
                    .OrderBy(d => d.DestinationName)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = db.Destinations.Where(d => d.DestinationName.Contains(searchString)).Count()
                    }
                };
                return View(model);
            }
            else
            {
                DestinationViewModel model = new DestinationViewModel
                {
                    Destinations = db.Destinations
                    .OrderBy(d => d.DestinationName)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = db.Destinations.Count()
                    }
                };
                return View(model);
            }


        }

        // GET: Destinations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destination destination = db.Destinations.Find(id);
            if (destination == null)
            {
                return HttpNotFound();
            }
            return View(destination);
        }

        // GET: Destinations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Destinations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DestinationID,DestinationName,DestinationLatitude,DestinationLongitude")] Destination destination)
        {
            if (ModelState.IsValid)
            {
                db.Destinations.Add(destination);
                db.SaveChanges();
                TempData["Success"] = "Successfully Added.";
                return RedirectToAction("Create");
            }

            return View(destination);
        }

        // GET: Destinations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destination destination = db.Destinations.Find(id);
            if (destination == null)
            {
                return HttpNotFound();
            }
            return View(destination);
        }

        // POST: Destinations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DestinationID,DestinationName,DestinationLatitude,DestinationLongitude")] Destination destination)
        {
            if (ModelState.IsValid)
            {
                db.Entry(destination).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(destination);
        }

        // GET: Destinations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destination destination = db.Destinations.Find(id);
            if (destination == null)
            {
                return HttpNotFound();
            }
            return View(destination);
        }

        // POST: Destinations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Destination destination = db.Destinations.Find(id);
            db.Destinations.Remove(destination);
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