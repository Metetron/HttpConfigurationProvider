using System.Threading.Tasks;
using FluentAssertions;
using Metetron.ConfigurationServer.Features.Apps.CreateApp;
using Metetron.ConfigurationServer.Models;
using Metetron.ConfigurationServer.Tests.TestHelpers;
using Xunit;

namespace Metetron.ConfigurationServer.Tests.Features.Apps.CreateApp
{
    public class CreateAppCommandValidatorTests : CqrsTestBase
    {
        private readonly CreateAppCommandValidator _validator;

        public CreateAppCommandValidatorTests()
        {
            _validator = new CreateAppCommandValidator(Mediator);
        }

        [Fact]
        public async Task Validate_AppNameIsEmpty_ShouldReturnValidationErrorAsync()
        {
            var command = new CreateAppCommand();

            var result = await _validator.ValidateAsync(command);

            result.Errors.Should().ContainValidationErrorFor(nameof(command.AppName));
        }

        [Fact]
        public async Task Validate_AppNameIsTooShort_ShouldReturnValidationErrorAsync()
        {
            var command = new CreateAppCommand { AppName = "12" };

            var result = await _validator.ValidateAsync(command);

            result.Errors.Should().ContainValidationErrorFor(nameof(command.AppName));
        }

        [Fact]
        public async Task Validate_AppNameIsTaken_ShouldReturnValidationErrorAsync()
        {
            var app = new App { Id = 1, AppName = "TestApp" };
            Context.Apps.Add(app);
            await Context.SaveChangesAsync();
            var command = new CreateAppCommand { AppName = "TestApp" };

            var result = await _validator.ValidateAsync(command);

            result.Errors.Should().ContainValidationErrorFor(nameof(command.AppName));
        }

        [Fact]
        public async Task Validate_AppNameIsValid_ShouldNotReturnValidationErrorAsync()
        {
            var command = new CreateAppCommand { AppName = "TestApp" };

            var result = await _validator.ValidateAsync(command);

            result.Errors.Should().NotContainValidationErrorFor(nameof(command.AppName));
        }
    }
}