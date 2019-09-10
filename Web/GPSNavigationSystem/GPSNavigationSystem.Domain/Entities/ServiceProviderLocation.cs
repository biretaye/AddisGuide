using FluentValidation;
using FluentValidation.Attributes;
using GPSNavigationSystem.Domain.DAL;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace GPSNavigationSystem.Domain.Entities
{
    [Serializable]
    [DataContract(IsReference = true)]
    [Validator(typeof(ServiceProviderLocationValidator))]
    public class ServiceProviderLocation
    {

        [DataMember]
        public int ServiceProviderLocationID { get; set; }


        [DataMember]
        [Display(Name = "Service Prodiver")]
        public int ServiceProviderID { get; set; }


        //[DataMember]
        //[Display(Name = "Destination")]
        //public  int DestinationID { get; set; }


        [DataMember]
        [Display(Name = "Latitude")]
        public double ServiceProviderLatitude { get; set; }


        [DataMember]
        [Display(Name = "Longitude")]
        public double ServiceProviderLongitude { get; set; }


        //[DataMember]
        //[Display(Name = "Destination")]
        //public virtual Destination Destination { get; set; }


        [DataMember]
        [Display(Name = "Service Provider")]
        public virtual ServiceProvider ServiceProvider { get; set; }
    }


    public class ServiceProviderLocationValidator : AbstractValidator<ServiceProviderLocation>
    {
        public ServiceProviderLocationValidator()
        {
            RuleFor(x => x.ServiceProviderID)
                .Must(BeUniqueServiceProvider)
                .WithMessage("The service provider in the provided location already exists.");

        }

        private bool BeUniqueServiceProvider(ServiceProviderLocation instance, 
                                                int serviceProviderID)
        {
            GPSNavigationSystemContext _db = new GPSNavigationSystemContext();
            var dbSPLocation = _db.ServiceProviderLocations
                                  .Where(x => x.ServiceProviderID == serviceProviderID &&
                                              x.ServiceProviderLongitude == instance.ServiceProviderLongitude &&
                                              x.ServiceProviderLatitude == instance.ServiceProviderLatitude)
                                  .SingleOrDefault();
            // if the item doesnt exist it will return null
            if (dbSPLocation == null)
            {
                return true;
            }
            return dbSPLocation.ServiceProviderLocationID == instance.ServiceProviderLocationID;

        }
    }
}