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
    public class TrafficSignsController : ApiController
    {
        private GPSNavigationSystemAPIContext db = new GPSNavigationSystemAPIContext();

        // GET: api/TrafficSigns
        public IQueryable<TrafficSign> GetTrafficSigns()
        {
            return db.TrafficSigns;
        }

        // GET: api/TrafficSigns/5
        [ResponseType(typeof(TrafficSign))]
        public IHttpActionResult GetTrafficSign(int id)
        {
            TrafficSign trafficSign = db.TrafficSigns.Find(id);
            if (trafficSign == null)
            {
                return NotFound();
            }

            return Ok(trafficSign);
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrafficSignExists(int id)
        {
            return db.TrafficSigns.Count(e => e.TrafficSignID == id) > 0;
        }
    }
}