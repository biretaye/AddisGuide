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
    public class ServiceProviderLocationsController : ApiController
    {
        private GPSNavigationSystemAPIContext db = new GPSNavigationSystemAPIContext();

        // GET: api/ServiceProviderLocations
        public IQueryable<ServiceProviderLocation> GetServiceProviderLocations()
        {
            return db.ServiceProviderLocations
                     //.Include(s => s.Destination)
                     .Include(s => s.ServiceProvider)
                     .Include(s => s.ServiceProvider.Category);
        }

        // GET: api/ServiceProviderLocations/5
        [ResponseType(typeof(ServiceProviderLocation))]
        public IHttpActionResult GetServiceProviderLocation(int id)
        {
            ServiceProviderLocation serviceProviderLocation = db.ServiceProviderLocations.Find(id);
            if (serviceProviderLocation == null)
            {
                return NotFound();
            }

            return Ok(serviceProviderLocation);
        }

        // GET: api/ServiceProviderLocations/GetServiceProviderLocationByName/sheraton
        [ResponseType(typeof(ServiceProviderLocation))]
        public IHttpActionResult GetServiceProviderLocationByName(String id)
        {
            var serviveProviders = from s in db.ServiceProviderLocations
                                   select s;
            if (!String.IsNullOrEmpty(id))
            {
                serviveProviders = serviveProviders
                    //.Include(s => s.Destination)
                     .Include(s => s.ServiceProvider)
                     .Include(s => s.ServiceProvider.Category)
                    .Where(c => c.ServiceProvider.ServiceProviderName.Contains(id));
                return Ok(serviveProviders);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/ServiceProviderLocations/GetServiceProviderLocationByCategory/hotel
        [ResponseType(typeof(ServiceProviderLocation))]
        public IHttpActionResult GetServiceProviderLocationByCategory(String id)
        {
            var serviveProviders = from s in db.ServiceProviderLocations
                                   select s;
            if (!String.IsNullOrEmpty(id))
            {
                serviveProviders = serviveProviders
                    //.Include(s => s.Destination)
                     .Include(s => s.ServiceProvider)
                     .Include(s => s.ServiceProvider.Category)
                    .Where(c => c.ServiceProvider.Category.CategoryName.Contains(id))
                    .OrderByDescending(s => s.ServiceProvider.Rating);
                return Ok(serviveProviders);
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

        private bool ServiceProviderLocationExists(int id)
        {
            return db.ServiceProviderLocations.Count(e => e.ServiceProviderLocationID == id) > 0;
        }
    }
}