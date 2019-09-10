using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Attributes;
using GPSNavigationSystem.Domain.DAL;
using System.Runtime.Serialization;

namespace GPSNavigationSystem.Domain.Entities
{
    [Serializable]
    [DataContract(IsReference = true)]
    [Validator(typeof(CategoryValidator))]
    public class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            this.ServiceProviders = new HashSet<ServiceProvider>();
        }

        [DataMember]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }


        [DataMember]
        [Required(ErrorMessage = "Please Enter a Category Name")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }


        //[DataMember]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceProvider> ServiceProviders { get; set; }
    }

    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName)
                .Must(BeUniqueCategory)
                .WithMessage("The catagory already exists.");
            

        }
        private bool BeUniqueCategory(Category category , string categoryName)
        {
            GPSNavigationSystemContext _db = new GPSNavigationSystemContext();
            var dbCategory = _db.Categories
                                .Where(x => x.CategoryName.Equals(categoryName))
                                .SingleOrDefault();
            if (dbCategory == null)
            {
                return true;
            }
            return dbCategory.CategoryID == category.CategoryID;


        }
    }
}
