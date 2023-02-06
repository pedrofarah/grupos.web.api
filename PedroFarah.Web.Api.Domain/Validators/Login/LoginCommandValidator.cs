using FluentValidation;
using PedroFarah.Web.Api.Domain.Commands;

namespace PedroFarah.Web.Api.Domain.Validators.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-mail não informado.");
        }
    }
}
