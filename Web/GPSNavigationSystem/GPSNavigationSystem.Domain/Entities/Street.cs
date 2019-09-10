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
    [Validator(typeof(StreetValidator))]
    public class Street
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Street()
        {
            this.Houses = new HashSet<House>();
        }

        [DataMember]
        public int StreetID { get; set; }

        [DataMember]
        [Display(Name = "Street Name")]
        [Required(ErrorMessage = "Please Enter a Street Name")]
        public string StreetName { get; set; }



        [DataMember]
        [Display(Name = "Start Latitude")]
        public Nullable<double> StreetStartLatitude { get; set; }

        [DataMember]
        [Display(Name = "Start Longitude")]
        public Nullable<double> StreetStartLongitude { get; set; }



        [DataMember]
        [Display(Name = "End Latitude")]
        public Nullable<double> StreetEndLatitude { get; set; }


        [DataMember]
        [Display(Name = "End Longitude")]
        public Nullable<double> StreetEndLongitude { get; set; }




        //[DataMember]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<House> Houses { get; set; }
    }


    public class StreetValidator : AbstractValidator<Street>
    {
        public StreetValidator()
        {
            RuleFor(x => x.StreetName)
                .Must(BeUniqueStreet)
                .WithMessage("The street already exists.");


        }
        private bool BeUniqueStreet(Street instance,  string street)
        {
            GPSNavigationSystemContext _db = new GPSNavigationSystemContext();
            var dbStreet = _db.Street
                              .Where(x => x.StreetName == street)
                              .SingleOrDefault();
            if (dbStreet == null)
            {
                return true;
            }
            return dbStreet.StreetID == instance.StreetID;


        }
    }
}