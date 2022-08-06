using System;
using System.Collections.Generic;
using Ddd.ManejoDeTienda.WebCompartido.Modelos;

namespace WebCompartido.Modelos.Proveedor
{
    public class RespuestaListarProveedores: RespuestaBase
    {
        public List<ProveedorDto> Proveedors { get; set; } = new List<ProveedorDto>();

        public int Total { get; set; }

        public RespuestaListarProveedores(Guid correlationId) : base(correlationId)
        {
        }

        public RespuestaListarProveedores()
        {
        }
    }
}
