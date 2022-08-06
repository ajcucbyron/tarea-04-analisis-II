using System;
using Ddd.ManejoDeTienda.WebCompartido.Modelos;

namespace WebCompartido.Modelos.Proveedor
{
    public class RespuestaCrearProveedor: RespuestaBase
    {
        public ProveedorDto Proveedor { get; set; } = new ProveedorDto();

        public RespuestaCrearProveedor(Guid correlationId) : base(correlationId)
        {
        }
        public RespuestaCrearProveedor()
        {
        }
    }
}
