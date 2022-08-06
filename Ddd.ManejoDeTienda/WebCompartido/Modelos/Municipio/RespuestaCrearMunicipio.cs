using System;
using Ddd.ManejoDeTienda.WebCompartido.Modelos;

namespace WebCompartido.Modelos.Municpio
{
    public class RespuestaCrearMunicpio: RespuestaBase
    {
        public MunicpioDto Municpio { get; set; } = new MunicpioDto();

        public RespuestaCrearMunicpio(Guid correlationId) : base(correlationId)
        {
        }
        public RespuestaCrearMunicpio()
        {
        }
    }
}
