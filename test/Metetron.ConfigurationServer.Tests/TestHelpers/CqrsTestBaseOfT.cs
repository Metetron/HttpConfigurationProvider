using AutoMapper;

namespace Metetron.ConfigurationServer.Tests.TestHelpers
{
    public class CqrsTestBase<TProfile> : CqrsTestBase where TProfile : Profile, new()
    {
        public IMapper Mapper { get; set; }

        public CqrsTestBase() : base()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<TProfile>());
            Mapper = configuration.CreateMapper();
        }
    }
}