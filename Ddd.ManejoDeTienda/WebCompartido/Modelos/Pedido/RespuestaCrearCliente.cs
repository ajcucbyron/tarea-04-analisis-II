using System;
using Ddd.ManejoDeTienda.WebCompartido.Modelos;

namespace WebCompartido.Modelos.Pedido
{
    public class RespuestaCrearPedido: RespuestaBase
    {
        public PedidoDto Pedido { get; set; } = new PedidoDto();

        public RespuestaCrearPedido(Guid correlationId) : base(correlationId)
        {
        }
        public RespuestaCrearPedido()
        {
        }
    }
}
