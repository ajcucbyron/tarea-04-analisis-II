using AutoMapper;
using Ddd.ManejoDeProveedor.Dominio.Agregados;
using Ddd.ManejoDeTienda.WebCompartido.Modelos.Proveedor;

namespace Api.MappingProfiles
{
    public class ProveedorProfile: Profile
    {
        public ProveedorProfile()
        {
            CreateMap<Proveedor, ProveedorDto>()
                .ForMember(dto => dto.ProveedorId, options => options.MapFrom(src => src.Id));
            CreateMap<ProveedorDto, Proveedor>()
                .ForMember(src => src.Id, options => options.MapFrom(dto => dto.ProveedorId));
            CreateMap<LlamadaCrearProveedor, Proveedor>();            
        }
    }
}
