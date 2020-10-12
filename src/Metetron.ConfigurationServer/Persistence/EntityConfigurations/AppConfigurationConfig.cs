using Metetron.ConfigurationServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Metetron.ConfigurationServer.Persistence.EntityConfigurations
{
    public class AppConfigurationConfig : IEntityTypeConfiguration<AppConfiguration>
    {
        public void Configure(EntityTypeBuilder<AppConfiguration> builder)
        {
            builder.Property(ac => ac.AppId)
                .IsRequired();

            builder.Property(ac => ac.Environment)
                .IsRequired();
        }
    }
}