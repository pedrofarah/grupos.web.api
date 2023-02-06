using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PedroFarah.Web.Api.Domain.Dtos.AppSettings;
using PedroFarah.Web.Api.Domain.Dtos.Gerente;
using PedroFarah.Web.Api.Domain.Services.TokenService.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PedroFarah.Web.Api.Domain.Services.TokenService
{
    public class TokenService : ITokenService
    {
        private readonly IOptions<AppSettingsDto> settings;

        public TokenService(IOptions<AppSettingsDto> settings)
        {
            this.settings = settings;
        }

        public string GenerateToken(GerenteDto dto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.Latin1.GetBytes(settings.Value.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim("GerenteId", dto.Id.ToString()),
                    new Claim(ClaimTypes.Email, dto.Email.ToString() )
                }),
                Expires = DateTime.UtcNow.AddHours(settings.Value.TokenExpirationHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
