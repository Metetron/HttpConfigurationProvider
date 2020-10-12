using Metetron.ConfigurationServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Metetron.ConfigurationServer.Persistence.EntityConfigurations
{
    public class AppConfig : IEntityTypeConfiguration<App>
    {
        public void Configure(EntityTypeBuilder<App> builder)
        {
            builder.Property(a => a.AppName)
                .IsRequired();

            builder.HasIndex(a => a.AppName)
                .IsUnique();
        }
    }
}