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
    public class MidPointsController : ApiController
    {
        private GPSNavigationSystemAPIContext db = new GPSNavigationSystemAPIContext();

        // GET: api/MidPoints
        public IQueryable<MidPoint> GetMidPoints()
        {
            return db.MidPoints;
        }

        // GET: api/MidPoints/5
        [ResponseType(typeof(MidPoint))]
        public IHttpActionResult GetMidPoint(int id)
        {
            MidPoint midPoint = db.MidPoints.Find(id);
            if (midPoint == null)
            {
                return NotFound();
            }

            return Ok(midPoint);
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MidPointExists(int id)
        {
            return db.MidPoints.Count(e => e.MidPointID == id) > 0;
        }
    }
}