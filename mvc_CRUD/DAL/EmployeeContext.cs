using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using mvc_CRUD.Models;

namespace mvc_CRUD.DAL
{
    public class EmployeeContext :DbContext
    {
        public EmployeeContext()
            : base("EmployeeDB") { }
        public DbSet<Employee> Empoyees { get; set; }
    }
}