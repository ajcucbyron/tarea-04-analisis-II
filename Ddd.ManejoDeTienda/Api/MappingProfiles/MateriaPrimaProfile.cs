using AutoMapper;
using Ddd.ManejoDeTienda.Dominio.Agregados;
using WebCompartido.Modelos.MateriaPrima;

namespace Api.MappingProfiles
{
    public class MateriaPrimaProfile: Profile
    {
        public MateriaPrimaProfile()
        {
            CreateMap<MateriaPrima, MateriaPrimaDto>()
                .ForMember(dto => dto.MateriaPrimaId, options => options.MapFrom(src => src.Id));
            CreateMap<MateriaPrimaDto, MateriaPrima>()
                .ForMember(src => src.Id, options => options.MapFrom(dto => dto.MateriaPrimaId));
            CreateMap<LlamadaCrearMateriaPrima, MateriaPrima>();
        }
    }
}
