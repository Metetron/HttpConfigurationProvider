using System;

namespace Metetron.ConfigurationServer.Models
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime? EditedOn { get; set; }
    }
}