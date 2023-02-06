using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PedroFarah.Web.Api.Domain.Commands;

namespace PedroFarah.Web.Api.Host.Controllers
{
    public class LoginController : BaseController
    {
        public LoginController(
            IMediator mediator)
        : base(mediator)
        {
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PostAsync([FromBody] LoginCommand value, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(value, cancellationToken);
            return Ok(result);
        }
    }
}
