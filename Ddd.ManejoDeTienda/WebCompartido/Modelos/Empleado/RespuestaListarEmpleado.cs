using System;
using System.Collections.Generic;
using Ddd.ManejoDeTienda.WebCompartido.Modelos;

namespace WebCompartido.Modelos.Empleado
{
    public class RespuestaListarEmpleados: RespuestaBase
    {
        public List<EmpleadoDto> Empleados { get; set; } = new List<EmpleadoDto>();

        public int Total { get; set; }

        public RespuestaListarEmpleados(Guid correlationId) : base(correlationId)
        {
        }

        public RespuestaListarEmpleados()
        {
        }
    }
}
