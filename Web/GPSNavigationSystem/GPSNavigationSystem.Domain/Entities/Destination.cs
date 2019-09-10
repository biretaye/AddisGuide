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
    [Validator(typeof(DestinationValidator))]
    public class Destination
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Destination()
        {
            this.StationDestinations = new HashSet<StationDestination>();
            //this.Houses = new HashSet<House>();
            //this.ServiceProviderLocations = new HashSet<ServiceProviderLocation>();
        }

        [DataMember]
        public int DestinationID { get; set; }


        [DataMember]
        [Display(Name = "Destination")]
        [Required(ErrorMessage = "Enter a Destination Name")]
        public string DestinationName { get; set; }


        [DataMember]
        [Display(Name = "Latitude")]
        public Nullable<double> DestinationLatitude { get; set; }


        [DataMember]
        [Display(Name = "Longitude")]
        public Nullable<double> DestinationLongitude { get; set; }


        //[DataMember]
        [Display(Name = "Station Destination")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StationDestination> StationDestinations { get; set; }


        ////[DataMember]
        //[Display(Name = "House")]
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<House> Houses { get; set; }


        ////[DataMember]
        //[Display(Name = "Service Provider")]
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ServiceProviderLocation> ServiceProviderLocations { get; set; }
    }


    public class DestinationValidator : AbstractValidator<Destination>
    {
        public DestinationValidator()
        {
            RuleFor(x => x.DestinationName)
                .Must(BeUniqueDestination)
                .WithMessage("The destination already exists.");


        }
        private bool BeUniqueDestination(Destination destinaion, string destination)
        {
            GPSNavigationSystemContext _db = new GPSNavigationSystemContext();
            var dbDestination = _db.Destinations
                                    .Where(x => x.DestinationName.Equals(destination))
                                    .SingleOrDefault();
            if (dbDestination == null)
            {
                return true;
            }

            return dbDestination.DestinationID == destinaion.DestinationID;


        }
    }
}