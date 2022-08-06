using System;
using System.Collections.Generic;

namespace Ddd.ManejoDeTienda.WebCompartido.Modelos.Tienda
{
    public class RespuestaListarTiendas: RespuestaBase
    {
        public List<TiendaDto> Tiendas { get; set; } = new List<TiendaDto>();

        public int Total { get; set; }

        public RespuestaListarTiendas(Guid correlationId) : base(correlationId)
        {
        }

        public RespuestaListarTiendas()
        {
        }
    }
}
