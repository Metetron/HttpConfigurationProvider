using System.Reflection;
using Metetron.ConfigurationServer.Models;
using Microsoft.EntityFrameworkCore;

namespace Metetron.ConfigurationServer.Persistence
{
    public class ConfigurationContext : DbContext
    {
        public DbSet<App> Apps { get; set; } = null!;
        public DbSet<AppConfiguration> AppConfigurations { get; set; } = null!;
        public DbSet<AppSetting> AppSettings { get; set; } = null!;

        public ConfigurationContext(DbContextOptions<ConfigurationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}