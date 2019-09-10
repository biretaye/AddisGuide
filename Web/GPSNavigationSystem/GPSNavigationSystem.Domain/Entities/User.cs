using FluentValidation;
using FluentValidation.Attributes;
using GPSNavigationSystem.Domain.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPSNavigationSystem.Domain.Entities
{
    [Validator(typeof(UserValidator))]
    public class User
    {
        [Required(ErrorMessage = "Please Enter a Valid User Name")]
        [Display(Name = "User Name")]
        [Key]
        public string username { get; set; }

        [Required(ErrorMessage = "Please Enter a Name")]
        [Display(Name = "First Name")]
        public string fname { get; set; }

        [Required(ErrorMessage = "Please Enter the Father Name")]
        [Display(Name = "Last Name")]
        public string lanme { get; set; }

        [Required(ErrorMessage = "Please Enter a Password")]
        [Display(Name = "Password")]
        public string password { get; set; }
    }


    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.username)
                .Must(BeUniqueUserName)
                .WithMessage("The user name already exists.");


        }
        private bool BeUniqueUserName(User instance, string username)
        {
            GPSNavigationSystemContext _db = new GPSNavigationSystemContext();
            var dbUser = _db.Users
                              .Where(x => x.username == username)
                              .SingleOrDefault();
            if (dbUser == null)
            {
                return true;
            } else
            {
                return false;
            }
            //return dbUser.username == instance.username;


        }
    }
}
