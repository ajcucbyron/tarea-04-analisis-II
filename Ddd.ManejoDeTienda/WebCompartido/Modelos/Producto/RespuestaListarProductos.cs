using System;
using System.Collections.Generic;
using Ddd.ManejoDeTienda.WebCompartido.Modelos;

namespace WebCompartido.Modelos.Producto
{
    public class RespuestaListarProductos: RespuestaBase
    {
        public List<ProductoDto> Productos { get; set; } = new List<ProductoDto>();

        public int Total { get; set; }

        public RespuestaListarProductos(Guid correlationId) : base(correlationId)
        {
        }

        public RespuestaListarProductos()
        {
        }
    }
}
