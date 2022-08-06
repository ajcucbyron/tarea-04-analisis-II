using System;

namespace Ddd.ManejoDeTienda.WebCompartido.Modelos
{
    public class RespuestaBase: MensajeBase
    {
        public RespuestaBase(Guid correlationId) : base()
        {
            base._correlationId = correlationId;
        }

        public RespuestaBase()
        {
        }
    }
}
