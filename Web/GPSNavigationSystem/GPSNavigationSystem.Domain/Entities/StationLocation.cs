using FluentValidation;
using FluentValidation.Attributes;
using GPSNavigationSystem.Domain.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace GPSNavigationSystem.Domain.Entities
{
    [Serializable]
    [DataContract(IsReference = true)]
    [Validator(typeof(StationLocationValidator))]
    public class StationLocation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StationLocation()
        {
            this.StationDestinations = new HashSet<StationDestination>();
        }

        [DataMember]
        public int StationLocationID { get; set; }


        [DataMember]
        [Display(Name = "Station Type")]
        [Required(ErrorMessage = "Please Enter a Station Type")]
        public string StationType { get; set; }


        [DataMember]
        [Display(Name = "Station Name")]
        [Required(ErrorMessage = "Plese Enter a Station Name")]
        public string StationName { get; set; }


        [DataMember]
        [Display(Name = "Latitude")]
        public Nullable<double> StationLatitude { get; set; }


        [DataMember]
        [Display(Name = "Longitude")]
        public Nullable<double> StationLongitude { get; set; }






        //[DataMember]
        [Display(Name = "Destinations")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StationDestination> StationDestinations { get; set; }
    }



    public class StationLocationValidator : AbstractValidator<StationLocation>
    {
        public StationLocationValidator()
        { 
            RuleFor(x => x.StationName)
                .Must(BeUniqueStationName)
                .WithMessage("The station already exists.");
                
        }
        
        private bool BeUniqueStationName(StationLocation instance, string stationName)
        {
            GPSNavigationSystemContext _db = new GPSNavigationSystemContext();
            var sbStation = _db.StationLocations
                                .Where(x => x.StationName == stationName &&
                                            x.StationType == instance.StationType)
                                .SingleOrDefault();
            
            if (sbStation == null ) 
            {
                return true;
            }
            return sbStation.StationLocationID == instance.StationLocationID;

        }


        //private bool BeUniqueStationType(string stationType)
        //{
        //    GPSNavigationSystemContext _db = new GPSNavigationSystemContext();
        //    if (_db.StationLocations
        //        .SingleOrDefault(x => x.StationType == stationType) == null)
        //    {
        //        return true;
        //    }
        //    return false;


        //}
    }
}