using AutoMapper;
using Ddd.ManejoDeTienda.Dominio.Agregados;
using Ddd.ManejoDeTienda.WebCompartido.Modelos.Tienda;

namespace Api.MappingProfiles
{
    public class TiendaProfile: Profile
    {
        public TiendaProfile()
        {
            CreateMap<Tienda, TiendaDto>()
                .ForMember(dto => dto.TiendaId, options => options.MapFrom(src => src.Id));
            CreateMap<TiendaDto, Tienda>()
                .ForMember(src => src.Id, options => options.MapFrom(dto => dto.TiendaId));
            CreateMap<LlamadaCrearTienda, Tienda>();            
        }
    }
}
