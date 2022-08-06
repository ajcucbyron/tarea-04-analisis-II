using System;
using Ddd.ManejoDeTienda.WebCompartido.Modelos;

namespace WebCompartido.Modelos.MateriaPrima
{
    public class RespuestaCrearMateriaPrima: RespuestaBase
    {
        public MateriaPrimaDto MateriaPrima { get; set; } = new MateriaPrimaDto();

        public RespuestaCrearMateriaPrima(Guid correlationId) : base(correlationId)
        {
        }
        public RespuestaCrearMateriaPrima()
        {
        }
    }
}
