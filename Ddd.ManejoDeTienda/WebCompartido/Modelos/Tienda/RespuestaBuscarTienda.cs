using System;

namespace Ddd.ManejoDeTienda.WebCompartido.Modelos.Tienda
{
    public class RespuestaBuscarTienda: RespuestaBase
    {
        public TiendaDto Tienda { get; set; } = new TiendaDto();

        public RespuestaBuscarTienda(Guid correlationId) : base(correlationId)
        {
        }

        public RespuestaBuscarTienda()
        {
        }
    }
}
