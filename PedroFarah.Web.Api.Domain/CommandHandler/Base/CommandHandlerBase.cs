using AutoMapper;
using FluentValidation;
using MediatR;
using PedroFarah.Web.Api.Infrastructure.Interfaces.DataModule;

namespace PedroFarah.Web.Api.Domain.CommandHandler.Base
{
    public class CommandHandlerBase<RequestCommand, Response> : IRequestHandler<RequestCommand, Response> where RequestCommand : IRequest<Response>
    {
        public CommandHandlerBase(
            IDataModule dataModule,
            IMapper mapper,
            IValidator<RequestCommand> validator)
        {
            this.dataModule = dataModule;
            this.mapper = mapper;
            this._validator = validator;
        }

        public readonly IDataModule dataModule;

        public readonly IMapper mapper;

        public readonly IValidator<RequestCommand> _validator;

        public virtual async Task<Response> Handle(RequestCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);

            return default;
        }
    }
}
