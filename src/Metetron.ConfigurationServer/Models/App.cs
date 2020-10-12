using System;

namespace Metetron.ConfigurationServer.Models
{
    public class App : IEntity
    {
        public int Id { get; set; }
        public string AppName { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public DateTime? EditedOn { get; set; }
    }
}