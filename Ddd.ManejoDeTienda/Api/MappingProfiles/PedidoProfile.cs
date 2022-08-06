using AutoMapper;
using Ddd.ManejoDeTienda.Dominio.Agregados;
using WebCompartido.Modelos.Pedido;

namespace Api.MappingProfiles
{
    public class ProductoProfile: Profile
    {
        public ProductoProfile()
        {
            CreateMap<Pedido, PedidoDto>()
                .ForMember(dto => dto.PedidoId, options => options.MapFrom(src => src.Id));
            CreateMap<PedidoDto, Pedido>()
                .ForMember(src => src.Id, options => options.MapFrom(dto => dto.PedidoId));
            CreateMap<LlamadaCrearPedido, Pedido>();
        }
    }
}
