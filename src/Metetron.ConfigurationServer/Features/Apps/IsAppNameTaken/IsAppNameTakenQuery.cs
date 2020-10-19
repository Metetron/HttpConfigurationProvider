using MediatR;

namespace Metetron.ConfigurationServer.Features.Apps.IsAppNameTaken
{
    public class IsAppNameTakenQuery : IRequest<bool>
    {
        public string AppName { get; set; } = string.Empty;
    }
}