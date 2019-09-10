using FluentValidation;
using GPSNavigationSystem.Domain.DAL;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using FluentValidation.Attributes;
using System.Runtime.Serialization;

namespace GPSNavigationSystem.Domain.Entities
{
    [Serializable]
    [DataContract(IsReference = true)]
    [Validator(typeof(HouseValidator))]
    public class House
    {
        [DataMember]
        public int HouseID { get; set; }

        [DataMember]
        [Display(Name = "House No")]
        [Required]
        public string HouseNumber { get; set; }

        //[DataMember]
        //[Display(Name = "Destination")]
        //public int DestinationID { get; set; }

        [DataMember]
        [Display(Name = "Street Name")]
        public int StreetID { get; set; }



        [DataMember]
        [Display(Name = "Latitude")]
        public Nullable<double> House_Latitude { get; set; }

        [DataMember]
        [Display(Name = "Longtiude")]
        public Nullable<double> House_Longitude { get; set; }



        //[DataMember]
        //[Display(Name = "Destination")]
        //public virtual Destination Destination { get; set; }


        [DataMember]
        [Display(Name = "Street Name")]
        public virtual Street Street { get; set; }
    }

    public class HouseValidator : AbstractValidator<House>
    {
        public HouseValidator()
        {
            RuleFor(x => x.HouseNumber)
                .Must(BeUniqueHouse)
                .WithMessage("The house in the given street already exists.");
            //RuleFor(x => x.House_Longitude)
            //    .Must(BeUniqueLongLat)
            //    .WithMessage("A house with the given location already exists. Please enter a new location ");


        }
        private bool BeUniqueHouse(House house, string houseNo)
        {
            GPSNavigationSystemContext _db = new GPSNavigationSystemContext();
            var dbHouse = _db.Houses
                         .Where(x => x.HouseNumber.Equals(houseNo) && 
                                     x.StreetID.Equals(house.StreetID))
                         .SingleOrDefault();
            if (dbHouse == null)
            {
                return true;
            }
            return dbHouse.HouseID == house.HouseID;


        }

        //private bool BeUniqueLongLat(House house, double? longitude)
        //{
        //    GPSNavigationSystemContext _db = new GPSNavigationSystemContext();
        //    var dbHouse = _db.Houses
        //                 .Where(x => x.House_Longitude == longitude && x.House_Latitude == house.House_Latitude)
        //                 .SingleOrDefault();
        //    if (dbHouse == null)
        //    {
        //        return true;
        //    }
        //    return dbHouse.HouseID == house.HouseID;


        //}
    }
}