using System;
using Ddd.ManejoDeTienda.WebCompartido.Modelos;

namespace WebCompartido.Modelos.Cliente
{
    public class RespuestaCrearCliente: RespuestaBase
    {
        public ClienteDto Cliente { get; set; } = new ClienteDto();

        public RespuestaCrearCliente(Guid correlationId) : base(correlationId)
        {
        }
        public RespuestaCrearCliente()
        {
        }
    }
}
