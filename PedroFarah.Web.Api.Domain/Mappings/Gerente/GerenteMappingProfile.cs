using AutoMapper;
using PedroFarah.Web.Api.Domain.Commands;
using PedroFarah.Web.Api.Domain.Dtos.Gerente;

namespace PedroFarah.Web.Api.Domain.Mappings.Gerente
{
    public class GerenteMappingProfile : Profile
    {
        public GerenteMappingProfile()
        {
            CreateMap<Entity.Gerente, GerenteDto>().ReverseMap();
            CreateMap<GerenteDto, LoginCommand>().ReverseMap();
        }
    }
}
