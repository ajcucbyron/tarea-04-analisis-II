using AutoMapper;
using Ddd.ManejoDeTienda.Dominio.Agregados;
using WebCompartido.Modelos.Vehiculo;

namespace Api.MappingProfiles
{
    public class ProductoProfile: Profile
    {
        public ProductoProfile()
        {
            CreateMap<Vehiculo, VehiculoDto>()
                .ForMember(dto => dto.VehiculoId, options => options.MapFrom(src => src.Id));
            CreateMap<VehiculoDto, Vehiculo>()
                .ForMember(src => src.Id, options => options.MapFrom(dto => dto.VehiculoId));
            CreateMap<LlamadaCrearVehiculo, Vehiculo>();
        }
    }
}
