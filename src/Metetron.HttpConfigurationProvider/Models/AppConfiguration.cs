using System.Collections.Generic;

namespace Metetron.HttpConfigurationProvider.Models
{
    public class AppConfiguration
    {
        public IEnumerable<Setting> Settings { get; set; }
    }
}