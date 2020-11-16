using AutoMapper;
using Metetron.ConfigurationServer.Models;

namespace Metetron.ConfigurationServer.Features.AppSettings.GetAppSettings
{
    public class GetAppSettingsProfile : Profile
    {
        public GetAppSettingsProfile()
        {
            CreateMap<AppSetting, AppSettingsModel>();
        }
    }
}