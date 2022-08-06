using System;
using System.Collections.Generic;
using Ddd.ManejoDeTienda.WebCompartido.Modelos;

namespace WebCompartido.Modelos.Vehiculo
{
    public class RespuestaListarVehiculos: RespuestaBase
    {
        public List<VehiculoDto> Vehiculos { get; set; } = new List<VehiculoDto>();

        public int Total { get; set; }

        public RespuestaListarVehiculos(Guid correlationId) : base(correlationId)
        {
        }

        public RespuestaListarVehiculos()
        {
        }
    }
}
