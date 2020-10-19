using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Metetron.ConfigurationServer.Features.Apps.CreateApp;
using Metetron.ConfigurationServer.Tests.TestHelpers;
using Xunit;

namespace Metetron.ConfigurationServer.Tests.Features.Apps.CreateApp
{
    public class CreateAppCommandHandlerTests : CqrsTestBase<CreateAppMappingProfile>
    {
        private readonly CreateAppCommandHandler _handler;

        public CreateAppCommandHandlerTests()
        {
            _handler = new CreateAppCommandHandler(Context, Mapper);
        }

        [Fact]
        public async Task Handle_WhenCalled_ShouldCreateTheAppAsync()
        {
            var command = new CreateAppCommand { AppName = "TestApp" };

            var result = await _handler.Handle(command, CancellationToken.None);

            result.Should().NotBeNull();
        }
    }
}