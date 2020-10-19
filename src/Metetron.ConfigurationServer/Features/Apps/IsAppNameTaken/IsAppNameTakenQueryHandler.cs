using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Metetron.ConfigurationServer.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Metetron.ConfigurationServer.Features.Apps.IsAppNameTaken
{
    public class IsAppNameTakenQueryHandler : IRequestHandler<IsAppNameTakenQuery, bool>
    {
        private readonly ConfigurationContext _context;

        public IsAppNameTakenQueryHandler(ConfigurationContext context)
        {
            _context = context;
        }

        public Task<bool> Handle(IsAppNameTakenQuery request, CancellationToken cancellationToken)
        {
            return _context.Apps.AnyAsync(a => a.AppName.Equals(request.AppName), cancellationToken);
        }
    }
}