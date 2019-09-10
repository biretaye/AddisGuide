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
    public class StationDestinationsController : ApiController
    {
        private GPSNavigationSystemAPIContext db = new GPSNavigationSystemAPIContext();

        // GET: api/StationDestinations
        public IQueryable<StationDestination> GetStationDestinations()
        {
            return db.StationDestinations.Include(sd => sd.Destination)
                                         .Include(sd => sd.StationLocation)
                                         .Include(sd => sd.MidPoint);
        }

        // GET: api/StationDestinations/GetStationDestination/5
        [ResponseType(typeof(StationDestination))]
        public IHttpActionResult GetStationDestination(int id)
        {
            //var sd = db.StationDestinations.Include(s => s.Destination).Include(s => s.StationLocation);
            var stationDestination = db.StationDestinations.Find(id);

            if (stationDestination == null)
            {
                return NotFound();
            }

            return Ok(stationDestination);
        }

        // GET: api/StationDestinations/GetDestinationsFromStation/4 kilo menelik
        [ResponseType(typeof(StationDestination))]
        public IHttpActionResult GetDestinationsFromStation(string id)
        {
            var stationDestination = from sd in db.StationDestinations
                                     select sd;
            if (!String.IsNullOrEmpty(id))
            {
                stationDestination = stationDestination
                    .Include(sd => sd.Destination)
                    .Include(sd => sd.StationLocation)
                    .Include(sd => sd.MidPoint)
                    .Where(sd => sd.StationLocation.StationName.Contains(id));
                return Ok(stationDestination);
            }

            return NotFound();
        }

        // GET: api/StationDestinations/GetStationsFromDestination/4 kilo
        [ResponseType(typeof(StationDestination))]
        public IHttpActionResult GetStationsFromDestination(string id)
        {
            var stationDestination = from sd in db.StationDestinations
                                     select sd;
            if (!String.IsNullOrEmpty(id))
            {
                stationDestination = stationDestination
                    .Include(sd => sd.Destination)
                    .Include(sd => sd.StationLocation)
                    .Include(sd => sd.MidPoint)
                    .Where(sd => sd.Destination.DestinationName.Contains(id));
                return Ok(stationDestination);
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

        private bool StationDestinationExists(int id)
        {
            return db.StationDestinations.Count(e => e.StationDestinationID == id) > 0;
        }
    }
}