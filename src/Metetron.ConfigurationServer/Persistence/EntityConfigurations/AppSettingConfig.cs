using Metetron.ConfigurationServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Metetron.ConfigurationServer.Persistence.EntityConfigurations
{
    public class AppSettingConfig : IEntityTypeConfiguration<AppSetting>
    {
        void IEntityTypeConfiguration<AppSetting>.Configure(EntityTypeBuilder<AppSetting> builder)
        {
            builder.Property(a => a.Key)
                .IsRequired();

            builder.Property(a => a.Value)
                .IsRequired();
        }
    }
}