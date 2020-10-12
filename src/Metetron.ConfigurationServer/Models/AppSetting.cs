using System;

namespace Metetron.ConfigurationServer.Models
{
    public class AppSetting : IEntity
    {
        public int Id { get; set; }
        public AppConfiguration? AppConfiguration { get; set; }
        public int AppConfigurationId { get; set; }
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public DateTime? EditedOn { get; set; }
    }
}