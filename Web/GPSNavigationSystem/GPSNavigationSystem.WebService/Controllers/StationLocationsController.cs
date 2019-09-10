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
    public class StationLocationsController : ApiController
    {
        private GPSNavigationSystemAPIContext db = new GPSNavigationSystemAPIContext();

        // GET: api/StationLocations
        public IQueryable<StationLocation> GetStationLocations()
        {
            return db.StationLocations;
        }

        // GET: api/StationLocations/5
        [ResponseType(typeof(StationLocation))]
        public IHttpActionResult GetStationLocation(int id)
        {
            StationLocation stationLocation = db.StationLocations.Find(id);
            if (stationLocation == null)
            {
                return NotFound();
            }

            return Ok(stationLocation);
        }

        // GET: api/StationLocations/GetStationTypeLocation/Taxi
        [ResponseType(typeof(StationLocation))]
        public IHttpActionResult GetStationTypeLocation(string id)
        {
            var stationLocation = from s in db.StationLocations select s;
            if (!String.IsNullOrEmpty(id))
            {
                stationLocation = stationLocation
                    .Where(s => s.StationType.Contains(id));
                return Ok(stationLocation);
            }

            return NotFound();
        }

        // GET: api/StationLocations/GetStationName/4-kilo menelik
        [ResponseType(typeof(StationLocation))]
        public IHttpActionResult GetStationName(string id)
        {
            var stationLocation = from s in db.StationLocations select s;
            if (!String.IsNullOrEmpty(id))
            {
                stationLocation = stationLocation
                    .Where(s => s.StationName.Contains(id));
                return Ok(stationLocation);
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

        private bool StationLocationExists(int id)
        {
            return db.StationLocations.Count(e => e.StationLocationID == id) > 0;
        }
    }
}