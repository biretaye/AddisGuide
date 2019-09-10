using FluentValidation;
using FluentValidation.Attributes;
using GPSNavigationSystem.Domain.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GPSNavigationSystem.Domain.Entities
{
    [Serializable]
    [DataContract(IsReference = true)]
    [Validator(typeof(MidPointValidator))]
    public class MidPoint
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MidPoint()
        {
            this.StationDestinations = new HashSet<StationDestination>();
        }

        [DataMember]
        [Display(Name = "Mid-Point ID")]
        public int MidPointID { get; set; }


        [DataMember]
        [Required(ErrorMessage = "Please Enter a Mid Point Name")]
        [Display(Name = "Mid-Point Name")]
        public string MidPointName { get; set; }

        [DataMember]
        [Display(Name = "Latitude")]
        public Nullable<double> MidPointLatitude { get; set; }


        [DataMember]
        [Display(Name = "Longitude")]
        public Nullable<double> MidPointLongitude { get; set; }



        //[DataMember]
        public virtual ICollection<StationDestination> StationDestinations { get; set; }
    }

    public class MidPointValidator : AbstractValidator<MidPoint>
    {
        public MidPointValidator()
        {
            RuleFor(x => x.MidPointName)
                .Must(BeUniqueMidPointName)
                .WithMessage("The midpoint name already exists.");


        }
        private bool BeUniqueMidPointName(MidPoint midpoint, string midpointName)
        {
            GPSNavigationSystemContext _db = new GPSNavigationSystemContext();
            var dbCategory = _db.MidPoints
                                .Where(x => x.MidPointName.Equals(midpointName))
                                .SingleOrDefault();
            if (dbCategory == null)
            {
                return true;
            }
            return dbCategory.MidPointID == midpoint.MidPointID;


        }
    }
}
