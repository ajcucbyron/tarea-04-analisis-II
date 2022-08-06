using System;
namespace Ddd.ManejoDeTienda.WebCompartido.Modelos
{
    public abstract class MensajeBase
    {
        protected Guid _correlationId = Guid.NewGuid();
        public Guid CorrelationId => _correlationId;
    }
}
