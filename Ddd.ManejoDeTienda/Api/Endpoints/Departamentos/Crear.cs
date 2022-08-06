using System;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Ddd.KernellCompartido.Interfaces;
using Ddd.ManejoDeTienda.Dominio.Agregados;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebCompartido.Modelos.Departamento;

namespace Api.Endpoints.Departamentos
{
    public class Crear : BaseAsyncEndpoint.WithRequest<LlamadaCrearDepartamento>.WithResponse<RespuestaCrearDepartamento>
    {
        private IRepositorio<Departamento, Guid> _repositorio;
        private readonly IMapper _mapper;

        public Crear(IRepositorio<Departamento, Guid> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpPost("api/Departamentos")]
        [SwaggerOperation(
            Summary = "Crea un nuevo Departamento",
            Description = "Endpoint usado para crear un Departamento",
            OperationId = "Departamentos.crear",
            Tags = new[] { "Departamentos" }
            )]
        public override async Task<ActionResult<RespuestaCrearDepartamento>> HandleAsync(LlamadaCrearDepartamento request, CancellationToken cancellationToken = default)
        {
            var respuesta = new RespuestaCrearDepartamento(request.CorrelationId);

            var nuevoDepartamento = _mapper.Map<Departamento>(request);
            nuevoDepartamento = await _repositorio.AgregarAsync(nuevoDepartamento, new CancellationToken());

            var dto = _mapper.Map<DepartamentoDto>(nuevoDepartamento);
            respuesta.Departamento = dto;

            return Ok(respuesta);
        }
    }
}
