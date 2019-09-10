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
    [Validator(typeof(ServiceProviderValidator))]
    public class ServiceProvider
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceProvider()
        {
            this.ServiceProviderLocations = new HashSet<ServiceProviderLocation>();
        }

        [DataMember]
        public int ServiceProviderID { get; set; }


        [DataMember]
        [Required(ErrorMessage = "Please Enter The Name of a Service Provider")]
        [Display(Name = "Name")]
        public string ServiceProviderName { get; set; }


        [DataMember]
        [Range(0,5, ErrorMessage = "Rating must be between 0 and 5")]
        public Nullable<int> Rating { get; set; }


        [DataMember]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }


        [DataMember]
        public virtual Category Category { get; set; }


        //[DataMember]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceProviderLocation> ServiceProviderLocations { get; set; }
    }


    public class ServiceProviderValidator : AbstractValidator<ServiceProvider>
    {
        public ServiceProviderValidator()
        {
            RuleFor(x => x.ServiceProviderName)
                .Must(BeUniqueServiceProvider)
                .WithMessage("The service provider already exists.");
            


        }
        private bool BeUniqueServiceProvider(ServiceProvider sp, string serviceProvider)
        {
            GPSNavigationSystemContext _db = new GPSNavigationSystemContext();
            var dbServiceProvider = _db.ServiceProviders
                                        .Where(x => x.ServiceProviderName.Equals(serviceProvider))
                                        .SingleOrDefault();
            if (dbServiceProvider == null)
            {
                return true;
            }

            return dbServiceProvider.ServiceProviderID == sp.ServiceProviderID;


        }
    }
}