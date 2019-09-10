using FluentValidation;
using FluentValidation.Attributes;
using GPSNavigationSystem.Domain.DAL;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System;
using System.Runtime.Serialization;

namespace GPSNavigationSystem.Domain.Entities
{
    [Serializable]
    [DataContract(IsReference = true)]
    [Validator(typeof(StationDestinationValidator))]
    public class StationDestination
    {

        [DataMember]
        public int StationDestinationID { get; set; }

        [DataMember]
        [Display(Name = "Station Name")]
        [Required(ErrorMessage = "Please Select a Station")]
        public int StationLocationID { get; set; }


        [DataMember]
        [Display(Name = "Destination Name")]
        [Required(ErrorMessage = "Please Select a Destination")]
        public int DestinationID { get; set; }


        [DataMember]
        [Display(Name = "Mid Point Name")]
        public Nullable<int> MidPointID { get; set; }


        //[DataMember]
        //[Display(Name = "MidPoint Latitude")]
        //public Nullable<double> MidPointLatitude { get; set; }


        //[DataMember]
        //[Display(Name = "MidPoint Longitude")]
        //public Nullable<double> MidPointLongitude { get; set; }


        [DataMember]
        public virtual Destination Destination { get; set; }

        [DataMember]
        public virtual StationLocation StationLocation { get; set; }

        [DataMember]
        public virtual MidPoint MidPoint { get; set; }


    }

    public class StationDestinationValidator : AbstractValidator<StationDestination>
    {
        public StationDestinationValidator()
        {
            RuleFor(x => x.StationLocationID)
                .Must(BeUniqueStationDestination)
                .WithMessage("The station with the destination already exists.");

        }

       
        private bool BeUniqueStationDestination(StationDestination instance, int stationID)
        {
            GPSNavigationSystemContext _db = new GPSNavigationSystemContext();
            var dbSD = _db.StationDestinations
                      .Where(x => x.StationLocationID == stationID &&
                                  x.DestinationID == instance.DestinationID)
                      .SingleOrDefault();
            if (dbSD == null)
            {
                return true;
            }
            return dbSD.StationDestinationID == instance.StationDestinationID;

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