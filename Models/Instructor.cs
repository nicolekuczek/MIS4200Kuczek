using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200Kuczek.Models
{
    public class Instructor
    {
        public int instructorID { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Instructor first name is required")]
        [StringLength(20)]
        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Student last name is required")]
        [StringLength(20)]
        public string lastName { get; set; }
        [Display(Name = "Most used email address")]
        [Required]
        [EmailAddress(ErrorMessage = "Enter your most frequently used email address")]
        public string email { get; set; }
        [Display(Name = "Office phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\(\d{3}\) |\d{3}-)\d{3}-\d{4}$",
        ErrorMessage = "Phone numbers must be in the format (xxx) xxx-xxxx or xxx-xxx-xxxx")]
        public string officePhoneNumber { get; set; }

        public ICollection<Course> course { get; set; }
        public string FullName { get
            { return lastName + ", " + firstName; }
                }
    }
}