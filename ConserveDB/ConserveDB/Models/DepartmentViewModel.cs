using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using ConserveDB.Data;

namespace ConserveDB.Models
{
    public class DepartmentViewModel
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DepartmentContext(serviceProvider.GetRequiredService<DbContextOptions<DepartmentContext>>()))
            {
                if (context.Department.Any())
                {
                    return;
                }
                context.Department.AddRange(
                    new Department
                    {
                        departmentName = "Management",
                        position = "CEO"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
