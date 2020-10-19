using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Metetron.ConfigurationServer.Features.Apps.IsAppNameTaken;
using Metetron.ConfigurationServer.Models;
using Metetron.ConfigurationServer.Tests.TestHelpers;
using Xunit;

namespace Metetron.ConfigurationServer.Tests.Features.Apps.IsAppNameTaken
{
    public class IsAppNameTakenQueryHandlerTests : CqrsTestBase
    {
        private readonly IsAppNameTakenQueryHandler _handler;

        public IsAppNameTakenQueryHandlerTests()
        {
            _handler = new IsAppNameTakenQueryHandler(Context);
        }

        [Fact]
        public async Task Handler_NoApps_ShouldReturnFalseAsync()
        {
            var query = new IsAppNameTakenQuery();

            var result = await _handler.Handle(query, CancellationToken.None);

            result.Should().BeFalse();
        }

        [Fact]
        public async Task Handler_AppDoesNotExist_ShouldReturnFalseAsync()
        {
            var query = new IsAppNameTakenQuery { AppName = "TestApp" };

            var result = await _handler.Handle(query, CancellationToken.None);

            result.Should().BeFalse();
        }

        [Fact]
        public async Task Handler_AppDoesExist_ShouldReturnTrueAsync()
        {
            var app = new App { Id = 1, AppName = "TestApp" };
            Context.Apps.Add(app);
            await Context.SaveChangesAsync();
            var query = new IsAppNameTakenQuery { AppName = "TestApp" };

            var result = await _handler.Handle(query, CancellationToken.None);

            result.Should().BeTrue();
        }
    }
}