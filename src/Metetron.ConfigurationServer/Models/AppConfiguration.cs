using System;
using System.Collections.Generic;

namespace Metetron.ConfigurationServer.Models
{
    public class AppConfiguration : IEntity
    {
        public int Id { get; set; }
        public App? App { get; set; }
        public int AppId { get; set; }
        public string? HostName { get; set; }
        public string Environment { get; set; } = "Production";
        public IList<AppSetting> AppSettings { get; set; } = new List<AppSetting>();
        public DateTime CreatedOn { get; set; }
        public DateTime? EditedOn { get; set; }
    }
}