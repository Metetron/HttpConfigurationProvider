using AutoMapper;
using Metetron.ConfigurationServer.Models;

namespace Metetron.ConfigurationServer.Features.Apps.CreateApp
{
    public class CreateAppMappingProfile : Profile
    {
        public CreateAppMappingProfile()
        {
            CreateMap<CreateAppCommand, App>();
        }
    }
}