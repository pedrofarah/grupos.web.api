using MediatR;
using PedroFarah.Web.Api.Domain.Commands.Base;

namespace PedroFarah.Web.Api.Domain.Commands
{
    public class LoginCommand : IRequest<CommandBaseResult>
    {
        public string Email { get; set; }
    }
}
