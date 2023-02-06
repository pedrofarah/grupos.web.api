using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Options;
using PedroFarah.Web.Api.Domain.CommandHandler.Base;
using PedroFarah.Web.Api.Domain.Commands;
using PedroFarah.Web.Api.Domain.Commands.Base;
using PedroFarah.Web.Api.Domain.Services.TokenService.Interfaces;
using PedroFarah.Web.Api.Infrastructure.Interfaces.DataModule;
using PedroFarah.Web.Api.Domain.Dtos.AppSettings;
using PedroFarah.Web.Api.Domain.Dtos.Gerente;

namespace PedroFarah.Web.Api.Domain.CommandHandler.Login
{
    public class LoginCommandHandler : CommandHandlerBase<LoginCommand, CommandBaseResult>
    {
        private readonly ITokenService tokenService;
        private readonly IOptions<AppSettingsDto> settings;

        public LoginCommandHandler(
            IDataModule dataModule,
            IMapper mapper,
            IValidator<LoginCommand> validator,
            ITokenService tokenService,
            IOptions<AppSettingsDto> settings)
        : base(dataModule, mapper, validator)
        {
            this.tokenService = tokenService;
            this.settings = settings;
        }

        public override async Task<CommandBaseResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            await base.Handle(request, cancellationToken);

            var _dto = await dataModule.GerenteRepository.GetAsync(x => x.Email.Equals(request.Email, StringComparison.Ordinal))
                ?? throw new ArgumentException("Gerente não localizado.");

            var objGerente = mapper.Map<GerenteDto>(_dto);

            return new CommandBaseResult()
            {
                Result = new
                {
                    AccessToken = tokenService.GenerateToken(objGerente),
                }
            };
        }
    }
}
