using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GPSNavigationSystem.Domain.DAL;
using GPSNavigationSystem.Domain.Entities;

namespace GPSNavigationSystem.WebService.Controllers
{
    public class CategoriesController : ApiController
    {
        private GPSNavigationSystemAPIContext db = new GPSNavigationSystemAPIContext();

        // GET: api/Categories
        public IQueryable<Category> GetCategories()
        {
            return db.Categories;//.Include(c => c.ServiceProviders);
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Category))]
        public IHttpActionResult GetCategory(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }



        // GET: api/Catagories/GetCatagoryByName/Hotel
        [ResponseType(typeof(Category))]

        public IHttpActionResult GetCatagoryByName(string id)
        {
            var categories = from c in db.Categories
                             select c;
            if (!String.IsNullOrEmpty(id))
            {
                categories = categories.Where(c => c.CategoryName.Contains(id));
                return Ok(categories);
            }
            else
            {
                return NotFound();
            }

        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(int id)
        {
            return db.Categories.Count(e => e.CategoryID == id) > 0;
        }
    }
}