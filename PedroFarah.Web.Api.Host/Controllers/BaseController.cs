using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PedroFarah.Web.Api.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public readonly IMediator mediator;

        public BaseController(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
