using System;
using Ddd.ManejoDeTienda.WebCompartido.Modelos;

namespace WebCompartido.Modelos.Tienda
{
    public class LlamadaBuscarTienda: LLamadaBase
    {
        public Guid TiendaId { get; set; }
    }
}
