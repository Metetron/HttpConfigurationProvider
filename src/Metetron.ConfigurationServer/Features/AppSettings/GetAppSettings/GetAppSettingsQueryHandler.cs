using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Metetron.ConfigurationServer.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Metetron.ConfigurationServer.Features.AppSettings.GetAppSettings
{
    public class GetAppSettingsQueryHandler : IRequestHandler<GetAppSettingsQuery, List<AppSettingsModel>>
    {
        private readonly ConfigurationContext _context;
        private readonly IConfigurationProvider _configuration;

        public GetAppSettingsQueryHandler(ConfigurationContext context, IConfigurationProvider configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public Task<List<AppSettingsModel>> Handle(GetAppSettingsQuery request, CancellationToken cancellationToken)
        {
            return _context.AppSettings
                .Where(c => c.AppConfiguration != null
                            && c.AppConfiguration.App != null
                            && c.AppConfiguration.HostName.Equals(request.HostName)
                            && c.AppConfiguration.App.AppName.Equals(request.AppName)
                            && c.AppConfiguration.Environment.Equals(request.Environment))
                .ProjectTo<AppSettingsModel>(_configuration)
                .ToListAsync(cancellationToken);
        }
    }
}