using System;
using Ddd.ManejoDeTienda.WebCompartido.Modelos;

namespace WebCompartido.Modelos.Empleado
{
    public class RespuestaCrearEmpleado: RespuestaBase
    {
        public EmpleadoDto Empleado { get; set; } = new EmpleadoDto();

        public RespuestaCrearEmpleado(Guid correlationId) : base(correlationId)
        {
        }
        public RespuestaCrearEmpleado()
        {
        }
    }
}
