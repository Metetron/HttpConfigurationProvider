using System;

namespace Metetron.HttpConfigurationProvider
{
    public class HttpConfigurationSourceSettings
    {
        public string ServerUri { get; set; }
        public string AppName { get; set; }
        public string HostName { get; set; } = Environment.MachineName;
    }
}