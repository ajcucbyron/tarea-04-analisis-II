using System;
using System.Collections.Generic;
using Ddd.ManejoDeTienda.WebCompartido.Modelos;

namespace WebCompartido.Modelos.Pedido
{
    public class RespuestaListarPedidos: RespuestaBase
    {
        public List<PedidoDto> Pedidos { get; set; } = new List<PedidoDto>();

        public int Total { get; set; }

        public RespuestaListarPedidos(Guid correlationId) : base(correlationId)
        {
        }

        public RespuestaListarPedidos()
        {
        }
    }
}
