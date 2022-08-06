using AutoMapper;
using Ddd.ManejoDeTienda.Dominio.Agregados;
using WebCompartido.Modelos.Producto;

namespace Api.MappingProfiles
{
    public class ProductoProfile: Profile
    {
        public ProductoProfile()
        {
            CreateMap<Producto, ProductoDto>()
                .ForMember(dto => dto.ProductoId, options => options.MapFrom(src => src.Id));
            CreateMap<ProductoDto, Producto>()
                .ForMember(src => src.Id, options => options.MapFrom(dto => dto.ProductoId));
            CreateMap<LlamadaCrearProducto, Producto>();
        }
    }
}
