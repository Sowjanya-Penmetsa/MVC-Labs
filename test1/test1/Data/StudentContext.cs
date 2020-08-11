using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using test1.Models;

namespace test1.Data
{
    public class StudentContext:DbContext
    {
        public StudentContext():base("DefaultConnection")
        {

        }
        public DbSet<Student> students { get; set; }
    }
}