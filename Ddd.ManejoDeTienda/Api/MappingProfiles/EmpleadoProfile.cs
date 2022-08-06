using AutoMapper;
using Ddd.ManejoDeTienda.Dominio.Agregados;
using WebCompartido.Modelos.Empleado;

namespace Api.MappingProfiles
{
    public class ProductoProfile: Profile
    {
        public ProductoProfile()
        {
            CreateMap<Empleado, EmpleadoDto>()
                .ForMember(dto => dto.EmpleadoId, options => options.MapFrom(src => src.Id));
            CreateMap<EmpleadoDto, Empleado>()
                .ForMember(src => src.Id, options => options.MapFrom(dto => dto.EmpleadoId));
            CreateMap<LlamadaCrearEmpleado, Empleado>();
        }
    }
}
