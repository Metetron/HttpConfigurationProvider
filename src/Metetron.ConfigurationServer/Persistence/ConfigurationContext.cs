using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Metetron.ConfigurationServer.Persistence
{
    public class ConfigurationContext : DbContext
    {
        public ConfigurationContext(DbContextOptions<ConfigurationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}