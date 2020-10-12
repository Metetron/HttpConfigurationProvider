using System;

namespace Metetron.ConfigurationServer.Models
{
    public class AppConfiguration : IEntity
    {
        public int Id { get; set; }
        public App? App { get; set; }
        public int AppId { get; set; }
        public string? HostName { get; set; }
        public string Environment { get; set; } = "Production";
        public DateTime CreatedOn { get; set; }
        public DateTime? EditedOn { get; set; }
    }
}