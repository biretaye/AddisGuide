using GPSNavigationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPSNavigationSystem.Domain.DTO
{
    public class ServiceProviderDTO
    {
        public int ServiceProviderID { get; set; }
        public string ServiceProviderName { get; set; }
        public int? Rating { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public ICollection<ServiceProviderLocation> ServiceProviderLocations { get; set; }
    }

    
}
