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
    public class HousesController : ApiController
    {
        private GPSNavigationSystemAPIContext db = new GPSNavigationSystemAPIContext();

        // GET: api/Houses
        public IQueryable<House> GetHouses()
        {
            return db.Houses.Include(s => s.Street);//.Include(d => d.Destination);
        }

        // GET: api/Houses/5
        [ResponseType(typeof(House))]
        public IHttpActionResult GetHouse(int id)
        {
            House house = db.Houses.Find(id);
            if (house == null)
            {
                return NotFound();
            }

            return Ok(house);
        }

        // GET: api/Houses/GetHouseUsingHouseNoAndStreet/B108_6 
        [ResponseType(typeof(House))]
        public IHttpActionResult GetHouseUsingHouseNoAndStreet(string id, string id2)
        {
            var house = from d in db.Houses
                         select d;
            if (!String.IsNullOrEmpty(id) && !String.IsNullOrEmpty(id2))
            {
                house = house.Where(c => c.HouseNumber.Equals(id.ToUpper()) && c.Street.StreetName.Equals(id2.ToUpper())).Include(d => d.Street);
                return Ok(house);
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

        private bool HouseExists(int id)
        {
            return db.Houses.Count(e => e.HouseID == id) > 0;
        }
    }
}