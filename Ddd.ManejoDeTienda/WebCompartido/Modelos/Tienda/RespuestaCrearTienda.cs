using System;

namespace Ddd.ManejoDeTienda.WebCompartido.Modelos.Tienda
{
    public class RespuestaCrearTienda: RespuestaBase
    {
        public TiendaDto Tienda { get; set; } = new TiendaDto();

        public RespuestaCrearTienda(Guid correlationId) : base(correlationId)
        {
        }

        public RespuestaCrearTienda()
        {
        }
    }
}
