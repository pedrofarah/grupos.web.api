using MediatR;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using PedroFarah.Web.Api.Domain.Services.TokenService.Interfaces;
using PedroFarah.Web.Api.Domain.Services.TokenService;

namespace PedroFarah.Web.Api.Domain
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapperConfiguration();

            services.AddMediatRConfiguration();

            services.AddFluentValidationConfiguration();

            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
        
        public static IServiceCollection AddMediatRConfiguration(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
        
        public static IServiceCollection AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }

        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
