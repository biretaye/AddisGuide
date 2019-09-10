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
    public class TrafficSignLocationsController : ApiController
    {
        private GPSNavigationSystemAPIContext db = new GPSNavigationSystemAPIContext();

        // GET: api/TrafficSignLocations
        public IQueryable<TrafficSignLocation> GetTrafficSignLocations()
        {
            return db.TrafficSignLocations.Include(ts => ts.TrafficSign);
        }

        // GET: api/TrafficSignLocations/GetTrafficSignLocation/5
        [ResponseType(typeof(TrafficSignLocation))]
        public IHttpActionResult GetTrafficSignLocation(int id)
        {
            TrafficSignLocation trafficSignLocation = db.TrafficSignLocations.Find(id);
            if (trafficSignLocation == null)
            {
                return NotFound();
            }

            return Ok(trafficSignLocation);
        }

        // GET: api/TrafficSignLocations/GetTrafficSignLocationByType/no parking
        [ResponseType(typeof(TrafficSignLocation))]
        public IHttpActionResult GetTrafficSignLocationByType(string id)
        {
            var trafficSign = from t in db.TrafficSignLocations select t;
            if (!String.IsNullOrEmpty(id))
            {
                trafficSign = trafficSign
                    .Include(s => s.TrafficSign)
                    .Where(s => s.TrafficSign.TrafficSignName.Contains(id));
                return Ok(trafficSign);
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

        private bool TrafficSignLocationExists(int id)
        {
            return db.TrafficSignLocations.Count(e => e.TrafficSignLocationID == id) > 0;
        }
    }
}