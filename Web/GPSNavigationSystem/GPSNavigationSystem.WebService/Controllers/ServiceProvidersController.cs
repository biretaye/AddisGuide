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
    public class ServiceProvidersController : ApiController
    {
        private GPSNavigationSystemAPIContext db = new GPSNavigationSystemAPIContext();

        // GET: api/ServiceProviders
        public IQueryable<ServiceProvider> GetServiceProviders()
        {
                
            return db.ServiceProviders;
        }

        // GET: api/ServiceProviders/GetServiceProvider/5
        [ResponseType(typeof(ServiceProvider))]
        public IHttpActionResult GetServiceProvider(int id)
        {

            ServiceProvider serviceProvider = db.ServiceProviders.Find(id);
            if (serviceProvider == null)
            {
                return NotFound();
            }

            return Ok(serviceProvider);
        }

        // GET: api/ServiceProviders/GetServiceProvidersByName/romina
        [ResponseType(typeof(ServiceProvider))]

        public IHttpActionResult GetServiceProvidersByName(string id)
        {
            var serviceProviders = from s in db.ServiceProviders select s;
            

            if (!String.IsNullOrEmpty(id))
            {
                serviceProviders = serviceProviders.Include(b => b.Category)
                                    .Where(c => c.ServiceProviderName.Contains(id))
                                    .OrderByDescending(s => s.Rating);
                return Ok(serviceProviders);
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

        private bool ServiceProviderExists(int id)
        {
            return db.ServiceProviders.Count(e => e.ServiceProviderID == id) > 0;
        }
    }
}