using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200Kuczek.Models
{
    public class Course
    {
        public int courseID { get; set; }
        [Display(Name = "Course Name")]
        [StringLength(50)]
        [Required]
        public string courseName { get; set; }
        [Display(Name = "Course Description")]
        [StringLength(50)]
        [Required]
        public string courseDescription { get; set; }
        public int instructorID { get; set; }
        public virtual Instructor instructor { get; set; }
        public ICollection<Enrolls> enrolls { get; set; }
    }
}