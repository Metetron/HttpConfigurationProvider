using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Metetron.ConfigurationServer.Models;
using Metetron.ConfigurationServer.Persistence;

namespace Metetron.ConfigurationServer.Features.Apps.CreateApp
{
    public class CreateAppCommandHandler : IRequestHandler<CreateAppCommand, int?>
    {
        private readonly ConfigurationContext _context;
        private readonly IMapper _mapper;

        public CreateAppCommandHandler(ConfigurationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int?> Handle(CreateAppCommand request, CancellationToken cancellationToken)
        {
            var app = _mapper.Map<App>(request);

            _context.Apps.Add(app);
            var changed = await _context.SaveChangesAsync(cancellationToken);

            if (changed != -1)
                return app.Id;

            return null;
        }
    }
}