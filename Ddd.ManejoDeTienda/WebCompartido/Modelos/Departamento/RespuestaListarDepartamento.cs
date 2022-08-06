using System;
using System.Collections.Generic;
using Ddd.ManejoDeTienda.WebCompartido.Modelos;

namespace WebCompartido.Modelos.Departamento
{
    public class RespuestaListarDepartamentos: RespuestaBase
    {
        public List<DepartamentoDto> Departamentos { get; set; } = new List<DepartamentoDto>();

        public int Total { get; set; }

        public RespuestaListarDepartamentos(Guid correlationId) : base(correlationId)
        {
        }

        public RespuestaListarDepartamentos()
        {
        }
    }
}
