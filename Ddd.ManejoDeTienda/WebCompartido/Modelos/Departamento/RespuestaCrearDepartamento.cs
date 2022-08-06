using System;
using Ddd.ManejoDeTienda.WebCompartido.Modelos;

namespace WebCompartido.Modelos.Departamento
{
    public class RespuestaCrearDepartamento: RespuestaBase
    {
        public DepartamentoDto Departamento { get; set; } = new DepartamentoDto();

        public RespuestaCrearDepartamento(Guid correlationId) : base(correlationId)
        {
        }
        public RespuestaCrearDepartamento()
        {
        }
    }
}
