using FluentValidation;
using FluentValidation.Attributes;
using GPSNavigationSystem.Domain.DAL;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace GPSNavigationSystem.Domain.Entities
{

    [DataContract(IsReference = true)]
    [Validator(typeof(SignValidator))]
    public class TrafficSign
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrafficSign()
        {
            this.TrafficSignLocations = new HashSet<TrafficSignLocation>();
        }

        [DataMember]
        public int TrafficSignID { get; set; }


        [DataMember]
        [Display(Name = "Sign Name")]
        [Required(ErrorMessage = "Please Enter a sign name")]
        public string TrafficSignName { get; set; }


        //[DataMember]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrafficSignLocation> TrafficSignLocations { get; set; }
    }
    public class SignValidator : AbstractValidator<TrafficSign>
    {
        public SignValidator()
        {
            RuleFor(x => x.TrafficSignName)
                .Must(BeUniqueSign)
                .WithMessage("The sign already exists.");


        }
        private bool BeUniqueSign(TrafficSign instance, string sign)
        {
            GPSNavigationSystemContext _db = new GPSNavigationSystemContext();
            var dbSign = _db.TrafficSigns
                            .Where(x => x.TrafficSignName == sign)
                            .SingleOrDefault();
            if (dbSign == null)
            {
                return true;
            }
            return dbSign.TrafficSignID == instance.TrafficSignID;


        }
    }
}