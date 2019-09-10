using GPSNavigationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GPSNavigationSystem.WebService.Models
{
    public class AllModels
    {
        public IEnumerable<House> Houses { get; set; }
        public IEnumerable<Street> Streets { get; set; }
        public IEnumerable<Destination> Destinations { get; set; }
        public IEnumerable<StationLocation> StationLocations { get; set; }
        public IEnumerable<StationDestination> StationDestinations { get; set; }
    }
}