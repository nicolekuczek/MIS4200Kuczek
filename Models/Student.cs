using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200Kuczek.Models
{
    public class Student
    {
        public int studentID { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Student first name is required")]
        [StringLength(20)]
        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Student last name is required")]
        [StringLength(20)]
        public string lastName { get; set; }
        [Display(Name = "Address")]
        [StringLength(50)]
        [Required]
        public string address { get; set; }
        [Display(Name = "City")]
        [StringLength(50)]
        [Required]
        public string city { get; set; }
        [Display(Name = "State")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "State must be two characters")]
        [Required]
        public string state { get; set; }
        [Display(Name = "Zip Code")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Zip code must be five numbers")]
        [Required]
        public string zip { get; set; }
        [Display(Name = "Most used email address")]
        [Required]
        [EmailAddress(ErrorMessage ="Enter your most frequently used email address")]
        public string email { get; set; }
        [Display(Name = "Mobile phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\(\d{3}\) |\d{3}-)\d{3}-\d{4}$",
            ErrorMessage = "Phone numbers must be in the format (xxx) xxx-xxxx or xxx-xxx-xxxx")]
        public string phone { get; set; }
        public ICollection<Enrolls> enrolls { get; set; }
        public string StudentFullName
        {
            get
            { return lastName + ", " + firstName; }
        }
    }
}
