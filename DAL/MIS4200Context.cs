using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MIS4200Kuczek.Models;

namespace MIS4200Kuczek.DAL
{
    public class MIS4200Context : DbContext 
    {
        public MIS4200Context() : base ("name=DefaultConnection")
        {

        }
        public DbSet<Student> students { get; set; }
        public DbSet<Enrolls> enrolls { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Instructor> instructors { get; set; }

    }
}