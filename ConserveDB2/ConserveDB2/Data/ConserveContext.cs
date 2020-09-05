using Microsoft.EntityFrameworkCore;
using ConserveDB2.Models;

namespace ConserveDB2.Data
{
    public class ConserveContext : DbContext
    {
        public ConserveContext(DbContextOptions<ConserveContext> options)
            : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
