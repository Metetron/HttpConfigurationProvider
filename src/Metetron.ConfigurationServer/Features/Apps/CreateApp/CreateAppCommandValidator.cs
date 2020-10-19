using FluentValidation;
using MediatR;
using Metetron.ConfigurationServer.Features.Apps.IsAppNameTaken;

namespace Metetron.ConfigurationServer.Features.Apps.CreateApp
{
    public class CreateAppCommandValidator : AbstractValidator<CreateAppCommand>
    {
        public CreateAppCommandValidator(IMediator mediator)
        {
            RuleFor(a => a.AppName)
                .NotEmpty()
                .MustAsync(async (name, token) => !await mediator.Send(new IsAppNameTakenQuery { AppName = name }, token))
                .MinimumLength(5);
        }
    }
}