using FluentValidation;
using FluentValidation.Attributes;
using GPSNavigationSystem.Domain.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GPSNavigationSystem.Domain.Entities
{
    [Serializable]
    [DataContract(IsReference = true)]
    [Validator(typeof(TrafficSignValidator))]
    public class TrafficSignLocation
    {
        [DataMember]
        public int TrafficSignLocationID { get; set; }

        [DataMember]
        [Display(Name = "Sign Name")]
        [Required(ErrorMessage = "Please Enter a sign name")]
        public int TrafficSignID { get; set; }

        [DataMember]
        [Display(Name = "Start Latitude")]
        public double TSLocationStartLatitude { get; set; }

        [DataMember]
        [Display(Name = "Start Longitude")]
        public double TSLocationStartLongitude { get; set; }



        [DataMember]
        [Display(Name = "End Latitude")]
        public double TSLocationEndLatitude { get; set; }

        [DataMember]
        [Display(Name = "End Longitude")]
        public double TSLocationEndLongitude { get; set; }




        [DataMember]
        public virtual TrafficSign TrafficSign { get; set; }
    }



    public class TrafficSignValidator : AbstractValidator<TrafficSignLocation>
    {
        public TrafficSignValidator()
        {
            RuleFor(x => x.TrafficSignID)
                .Must(BeUniqueTrafficSign)
                .WithMessage("The sign in the given location already exists.");

        }


        private bool BeUniqueTrafficSign(TrafficSignLocation instance, int trafficSignID)
        {
            GPSNavigationSystemContext _db = new GPSNavigationSystemContext();
            var dbTSLocation = _db.TrafficSignLocations
                                  .Where(x => x.TrafficSignID == trafficSignID &&
                                         x.TSLocationEndLatitude == instance.TSLocationEndLatitude &&
                                         x.TSLocationEndLongitude == instance.TSLocationEndLongitude &&
                                         x.TSLocationStartLatitude == instance.TSLocationStartLatitude &&
                                         x.TSLocationStartLongitude == instance.TSLocationStartLongitude)
                                  .SingleOrDefault();
            if (dbTSLocation == null)
            {
                return true;
            }
            return dbTSLocation.TrafficSignLocationID == instance.TrafficSignLocationID;

        }
    }
}
