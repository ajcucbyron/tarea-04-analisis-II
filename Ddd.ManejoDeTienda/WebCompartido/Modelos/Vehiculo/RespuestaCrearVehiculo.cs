using System;
using Ddd.ManejoDeTienda.WebCompartido.Modelos;

namespace WebCompartido.Modelos.Vehiculo
{
    public class RespuestaCrearVehiculo: RespuestaBase
    {
        public VehiculoDto Vehiculo { get; set; } = new VehiculoDto();

        public RespuestaCrearVehiculo(Guid correlationId) : base(correlationId)
        {
        }
        public RespuestaCrearVehiculo()
        {
        }
    }
}
