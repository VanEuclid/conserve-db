using System;
using Microsoft.EntityFrameworkCore;
using ConserveDB.Models;

namespace ConserveDB.Data
{
    public class DepartmentContext : DbContext
    {
       public DepartmentContext(DbContextOptions<DepartmentContext> options) : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
    }
}
