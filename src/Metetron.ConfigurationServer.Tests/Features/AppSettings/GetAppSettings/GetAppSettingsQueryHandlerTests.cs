using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Metetron.ConfigurationServer.Features.AppSettings.GetAppSettings;
using Metetron.ConfigurationServer.Models;
using Metetron.ConfigurationServer.Tests.TestHelpers;
using Xunit;

namespace Metetron.ConfigurationServer.Tests.Features.AppSettings.GetAppSettings
{
    public class GetAppSettingsQueryHandlerTests : CqrsTestBase<GetAppSettingsProfile>
    {
        private readonly GetAppSettingsQueryHandler _handler;

        public GetAppSettingsQueryHandlerTests()
        {
            _handler = new GetAppSettingsQueryHandler(Context, Mapper.ConfigurationProvider);
        }

        [Fact]
        public async Task Handle_NoAppWithTheGivenName_ShouldReturnAnEmptyListAsync()
        {
            var query = new GetAppSettingsQuery { AppName = "TestApp", HostName = "PC1" };

            var result = await _handler.Handle(query, CancellationToken.None);

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task Handle_NoAppConfigForTheHostname_ShouldReturnAnEmptyListAsync()
        {
            await InsertTestDataAsync();
            var query = new GetAppSettingsQuery { AppName = "TestApp", HostName = "PC2", Environment = "Production" };

            var result = await _handler.Handle(query, CancellationToken.None);

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task Handle_NoAppConfigForTheGivenEnvironment_ShouldReturnAnEmptyListAsync()
        {
            await InsertTestDataAsync();
            var query = new GetAppSettingsQuery { AppName = "TestApp", HostName = "PC1", Environment = "Development" };

            var result = await _handler.Handle(query, CancellationToken.None);

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task Handle_AppConfigDoesExist_ShouldReturnTheAppSettingsAsync()
        {
            await InsertTestDataAsync();
            var query = new GetAppSettingsQuery { AppName = "TestApp", HostName = "PC1", Environment = "Production" };

            var result = await _handler.Handle(query, CancellationToken.None);

            result.Should().HaveCount(2);
        }

        private async Task InsertTestDataAsync()
        {
            var appConfig = new AppConfiguration
            {
                Id = 1,
                App = new App
                {
                    Id = 1,
                    AppName = "TestApp"
                },
                AppSettings = new List<AppSetting>
                {
                    new AppSetting {Id = 1, Key = "TestSetting", Value = "TestValue"},
                    new AppSetting {Id = 2, Key = "TestSetting2", Value = "2"}
                },
                Environment = "Production",
                HostName = "PC1"
            };

            Context.AppConfigurations.Add(appConfig);

            await Context.SaveChangesAsync();
        }
    }
}