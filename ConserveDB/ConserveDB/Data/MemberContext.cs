using Microsoft.EntityFrameworkCore;
using ConserveDB.Models;

namespace ConserveDB.Data
{
    public class MemberContext : DbContext
    {
        public MemberContext(DbContextOptions<MemberContext> options)
            : base(options)
        {
        }

        public DbSet<Member> Member { get; set; }
    }
}
