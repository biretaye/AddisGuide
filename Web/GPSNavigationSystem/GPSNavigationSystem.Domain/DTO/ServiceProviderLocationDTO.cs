using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPSNavigationSystem.Domain.DTO
{
    public class ServiceProviderLocationDTO
    {
        public int ServiceProviderLocationID { get; set; }
        public int? ServiceProviderID { get; set; }
        public int? DestinationID { get; set; }
        public int? ServiceProviderLatitude { get; set; }
        public int? ServiceProviderLongitude { get; set; }
        public string ServiceProviderName { get; set; }

        public int? Rating { get; set; }
        public string CatagoryName { get; set; }

        public string DestinationName { get; set; }
        public double? DestinationLatitude { get; set; }
        public double? DestinationLongitude { get; set; }
    }
}
