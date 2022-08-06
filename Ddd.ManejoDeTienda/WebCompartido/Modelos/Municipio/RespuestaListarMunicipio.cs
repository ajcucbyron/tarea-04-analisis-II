using System;
using System.Collections.Generic;
using Ddd.ManejoDeTienda.WebCompartido.Modelos;

namespace WebCompartido.Modelos.Municpio
{
    public class RespuestaListarMunicpios: RespuestaBase
    {
        public List<MunicpioDto> Municpios { get; set; } = new List<MunicpioDto>();

        public int Total { get; set; }

        public RespuestaListarMunicpios(Guid correlationId) : base(correlationId)
        {
        }

        public RespuestaListarMunicpios()
        {
        }
    }
}
