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
    public class ServiceProvidersController : Controller
    {
        private GPSNavigationSystemContext db = new GPSNavigationSystemContext();
        public int PageSize = 10;  // ten items per page

        // GET: ServiceProviders
        public ActionResult Index(string searchString, int page = 1)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                ServiceProviderViewModel model = new ServiceProviderViewModel
                {
                    ServiceProviders = db.ServiceProviders
                    .OrderBy(d => d.ServiceProviderName)
                    .Include(s => s.Category)
                    .Where(c => c.ServiceProviderName.Contains(searchString) || c.Category.CategoryName.Contains(searchString))
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = db.ServiceProviders.Count()
                    }
                };
                return View(model);
            }
            else
            {
                ServiceProviderViewModel model = new ServiceProviderViewModel
                {
                    ServiceProviders = db.ServiceProviders
                    .OrderBy(d => d.ServiceProviderName)
                    .Include(s => s.Category)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = db.ServiceProviders.Count()
                    }
                };
                return View(model);
            }
        }

        // GET: ServiceProviders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceProvider serviceProvider = db.ServiceProviders.Find(id);
            if (serviceProvider == null)
            {
                return HttpNotFound();
            }
            return View(serviceProvider);
        }

        // GET: ServiceProviders/Create
        public ActionResult Create()
        {
            var categories = from c in db.Categories
                             orderby c.CategoryName
                             select c;
            ViewBag.CategoryID = new SelectList(categories, "CategoryID", "CategoryName");
            return View();
        }

        

        // POST: ServiceProviders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServiceProviderID,ServiceProviderName,Rating,CategoryID")] ServiceProvider serviceProvider)
        {
            if (ModelState.IsValid)
            {
                db.ServiceProviders.Add(serviceProvider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var categories = from c in db.Categories
                             orderby c.CategoryName
                             select c;
            ViewBag.CategoryID = new SelectList(categories, "CategoryID", "CategoryName", serviceProvider.CategoryID);
            return View(serviceProvider);
        }

        // GET: ServiceProviders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceProvider serviceProvider = db.ServiceProviders.Find(id);
            if (serviceProvider == null)
            {
                return HttpNotFound();
            }

            var categories = from c in db.Categories
                             orderby c.CategoryName
                             select c;
            ViewBag.CategoryID = new SelectList(categories, "CategoryID", "CategoryName", serviceProvider.CategoryID);
            return View(serviceProvider);
        }

        // POST: ServiceProviders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServiceProviderID,ServiceProviderName,Rating,CategoryID")] ServiceProvider serviceProvider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceProvider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var categories = from c in db.Categories
                             orderby c.CategoryName
                             select c;
            ViewBag.CategoryID = new SelectList(categories, "CategoryID", "CategoryName", serviceProvider.CategoryID);
            return View(serviceProvider);
        }

        // GET: ServiceProviders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceProvider serviceProvider = db.ServiceProviders.Find(id);
            if (serviceProvider == null)
            {
                return HttpNotFound();
            }
            return View(serviceProvider);
        }

        // POST: ServiceProviders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceProvider serviceProvider = db.ServiceProviders.Find(id);
            db.ServiceProviders.Remove(serviceProvider);
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
