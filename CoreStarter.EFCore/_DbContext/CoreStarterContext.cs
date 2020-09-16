using CoreStarter.EFCore.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreStarter.EFCore._DbContext
{
    public class CoreStarterContext : IdentityDbContext<AppUser>
    {
        public CoreStarterContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}
