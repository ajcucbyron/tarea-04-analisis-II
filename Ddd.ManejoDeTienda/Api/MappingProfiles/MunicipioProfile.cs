using AutoMapper;
using Ddd.ManejoDeTienda.Dominio.Agregados;
using WebCompartido.Modelos.Municipio;

namespace Api.MappingProfiles
{
    public class ProductoProfile: Profile
    {
        public ProductoProfile()
        {
            CreateMap<Municipio, MunicipioDto>()
                .ForMember(dto => dto.MunicipioId, options => options.MapFrom(src => src.Id));
            CreateMap<MunicipioDto, Municipio>()
                .ForMember(src => src.Id, options => options.MapFrom(dto => dto.MunicipioId));
            CreateMap<LlamadaCrearMunicipio, Municipio>();
        }
    }
}
