using System;
using System.Collections.Generic;
using GPSNavigationSystem.Domain.Entities;

namespace GPSNavigationSystem.DataEntry.Models
{
    public class StationDestinationViewModel
    {
        public IEnumerable<StationDestination> StationDestinations { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}