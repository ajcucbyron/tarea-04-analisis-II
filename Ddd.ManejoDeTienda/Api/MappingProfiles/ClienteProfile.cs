using AutoMapper;
using Ddd.ManejoDeTienda.Dominio.Agregados;
using WebCompartido.Modelos.Cliente;

namespace Api.MappingProfiles
{
    public class ProductoProfile: Profile
    {
        public ProductoProfile()
        {
            CreateMap<Cliente, ClienteDto>()
                .ForMember(dto => dto.ClienteId, options => options.MapFrom(src => src.Id));
            CreateMap<ClienteDto, Cliente>()
                .ForMember(src => src.Id, options => options.MapFrom(dto => dto.ClienteId));
            CreateMap<LlamadaCrearCliente, Cliente>();
        }
    }
}
