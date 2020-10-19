using MediatR;

namespace Metetron.ConfigurationServer.Features.Apps.CreateApp
{
    public class CreateAppCommand : IRequest<int?>
    {
        public string AppName { get; set; } = string.Empty;
    }
}