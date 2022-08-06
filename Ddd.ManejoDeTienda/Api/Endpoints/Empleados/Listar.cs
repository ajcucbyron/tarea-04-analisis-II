using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Ddd.KernellCompartido.Interfaces;
using Ddd.ManejoDeTienda.Dominio.Agregados;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebCompartido.Modelos.Empleado;

namespace Api.Endpoints.Empleados
{
    public class Listar : BaseAsyncEndpoint
        .WithRequest<LlamadaListarEmpleados>
        .WithResponse<RespuestaListarEmpleados>
    {
        private readonly IRepositorio<Empleado, Guid> _repositorio;
        private readonly IMapper _mapper;

        public Listar(IRepositorio<Empleado, Guid> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpGet("api/Empleados")]
        [SwaggerOperation(
            Summary = "Lista los Empleados existentes",
            Description = "Lista los Empleados existentes",
            OperationId = "Empleados.listar",
            Tags = new[] { "Empleados" }
            )]
        public override async Task<ActionResult<RespuestaListarEmpleados>> HandleAsync([FromQuery] LlamadaListarEmpleados request, CancellationToken cancellationToken = default)
        {
            var respuesta = new RespuestaListarEmpleados(request.CorrelationId);

            var Empleados = await _repositorio.ListarTodoAsync(cancellationToken);
            if (Empleados is null) return NotFound();
            respuesta.Empleados.AddRange(Empleados.Select(x => _mapper.Map<EmpleadoDto>(x)));
            respuesta.Total = respuesta.Empleados.Count;

            return Ok(respuesta);
        }
    }
}
