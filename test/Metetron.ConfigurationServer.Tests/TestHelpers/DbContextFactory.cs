using System;
using Metetron.ConfigurationServer.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Metetron.ConfigurationServer.Tests.TestHelpers
{
    public class DbContextFactory
    {
        public static ConfigurationContext Create()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ConfigurationContext>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            var context = new ConfigurationContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            return context;
        }

        public static void Dispose(ConfigurationContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}