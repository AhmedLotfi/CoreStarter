using CoreStarter.EFCore.Entites;
using Microsoft.EntityFrameworkCore;

namespace CoreStarter.EFCore._DbContext
{
    public class CoreStarterContext : DbContext
    {
        public CoreStarterContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}
