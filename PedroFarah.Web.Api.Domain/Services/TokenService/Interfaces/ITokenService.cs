using PedroFarah.Web.Api.Domain.Dtos.Gerente;

namespace PedroFarah.Web.Api.Domain.Services.TokenService.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(GerenteDto dto);
    }
}
