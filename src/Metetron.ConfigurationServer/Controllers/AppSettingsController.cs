using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Metetron.ConfigurationServer.Features.AppSettings.GetAppSettings;
using Microsoft.AspNetCore.Mvc;

namespace Metetron.ConfigurationServer.Controllers
{
    [ApiController]
    [Route("/api/appsettings")]
    public class AppSettingsController : Controller
    {
        private readonly IMediator _mediator;

        public AppSettingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<List<AppSettingsModel>>> GetAppSettingsAsync([FromBody] GetAppSettingsQuery query)
        {
            var settings = await _mediator.Send(query);

            return Ok(Json(settings).Value);
        }
    }
}