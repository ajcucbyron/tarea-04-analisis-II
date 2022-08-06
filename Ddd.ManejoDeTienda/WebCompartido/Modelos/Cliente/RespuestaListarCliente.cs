using System;
using System.Collections.Generic;
using Ddd.ManejoDeTienda.WebCompartido.Modelos;

namespace WebCompartido.Modelos.Cliente
{
    public class RespuestaListarClientes: RespuestaBase
    {
        public List<ClienteDto> Clientes { get; set; } = new List<ClienteDto>();

        public int Total { get; set; }

        public RespuestaListarClientes(Guid correlationId) : base(correlationId)
        {
        }

        public RespuestaListarClientes()
        {
        }
    }
}
