using System;
using Ddd.ManejoDeTienda.WebCompartido.Modelos;

namespace WebCompartido.Modelos.Producto
{
    public class RespuestaCrearProducto: RespuestaBase
    {
        public ProductoDto Producto { get; set; } = new ProductoDto();

        public RespuestaCrearProducto(Guid correlationId) : base(correlationId)
        {
        }
        public RespuestaCrearProducto()
        {
        }
    }
}
