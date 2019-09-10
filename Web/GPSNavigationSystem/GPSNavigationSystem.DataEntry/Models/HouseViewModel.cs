using GPSNavigationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GPSNavigationSystem.DataEntry.Models
{
    public class HouseViewModel
    {
        public IEnumerable<House> Houses { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}