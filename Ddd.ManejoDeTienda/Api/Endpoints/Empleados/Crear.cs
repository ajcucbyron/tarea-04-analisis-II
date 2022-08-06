using System;
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
    public class Crear : BaseAsyncEndpoint.WithRequest<LlamadaCrearEmpleado>.WithResponse<RespuestaCrearEmpleado>
    {
        private IRepositorio<Empleado, Guid> _repositorio;
        private readonly IMapper _mapper;

        public Crear(IRepositorio<Empleado, Guid> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpPost("api/Empleados")]
        [SwaggerOperation(
            Summary = "Crea un nuevo Empleado",
            Description = "Endpoint usado para crear un Empleado",
            OperationId = "Empleados.crear",
            Tags = new[] { "Empleados" }
            )]
        public override async Task<ActionResult<RespuestaCrearEmpleado>> HandleAsync(LlamadaCrearEmpleado request, CancellationToken cancellationToken = default)
        {
            var respuesta = new RespuestaCrearEmpleado(request.CorrelationId);

            var nuevoEmpleado = _mapper.Map<Empleado>(request);
            nuevoEmpleado = await _repositorio.AgregarAsync(nuevoEmpleado, new CancellationToken());

            var dto = _mapper.Map<EmpleadoDto>(nuevoEmpleado);
            respuesta.Empleado = dto;

            return Ok(respuesta);
        }
    }
}
