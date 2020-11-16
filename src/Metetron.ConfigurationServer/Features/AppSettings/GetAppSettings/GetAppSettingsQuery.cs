using System.Collections.Generic;
using MediatR;

namespace Metetron.ConfigurationServer.Features.AppSettings.GetAppSettings
{
    public class GetAppSettingsQuery : IRequest<List<AppSettingsModel>>
    {
        public string AppName { get; set; } = string.Empty;
        public string HostName { get; set; } = string.Empty;
    }
}