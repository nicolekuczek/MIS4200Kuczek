using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200Kuczek.Models
{
    public class Enrolls
    {
        public int enrollsID { get; set; }
        public int studentID { get; set; }
        public int courseID { get; set; }
        [Display(Name = "Letter Grade")]
        [Required(ErrorMessage = "Letter Grade is required")]
        [StringLength(1)]
        public string letterGrade { get; set; }
        public virtual Student student { get; set; }
        public virtual Course course { get; set; }
    }
}