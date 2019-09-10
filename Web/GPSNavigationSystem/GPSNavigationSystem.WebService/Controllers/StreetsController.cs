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
    public class StreetsController : ApiController
    {
        private GPSNavigationSystemAPIContext db = new GPSNavigationSystemAPIContext();

        // GET: api/Streets
        public IQueryable<Street> GetStreet()
        {
            return db.Street;
        }

        // GET: api/Streets/GetStreet/5
        [ResponseType(typeof(Street))]
        public IHttpActionResult GetStreet(int id)
        {
            Street street = db.Street.Find(id);
            if (street == null)
            {
                return NotFound();
            }

            return Ok(street);
        }

        // GET: api/Streets/GetStreetUsingStreetName/BL_03_622 
        [ResponseType(typeof(Street))]
        public IHttpActionResult GetStreetUsingStreetName(string id)
        {
            var street = from d in db.Street
                            select d;
            if (!String.IsNullOrEmpty(id))
            {
                street = street.Where(c => c.StreetName.Contains(id));
                return Ok(street);
            }

            return NotFound();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StreetExists(int id)
        {
            return db.Street.Count(e => e.StreetID == id) > 0;
        }
    }
}