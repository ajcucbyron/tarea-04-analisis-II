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
using WebCompartido.Modelos.Departamento;

namespace Api.Endpoints.Departamentos
{
    public class Listar : BaseAsyncEndpoint
        .WithRequest<LlamadaListarDepartamentos>
        .WithResponse<RespuestaListarDepartamentos>
    {
        private readonly IRepositorio<Departamento, Guid> _repositorio;
        private readonly IMapper _mapper;

        public Listar(IRepositorio<Departamento, Guid> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpGet("api/Departamentos")]
        [SwaggerOperation(
            Summary = "Lista los Departamentos existentes",
            Description = "Lista los Departamentos existentes",
            OperationId = "Departamentos.listar",
            Tags = new[] { "Departamentos" }
            )]
        public override async Task<ActionResult<RespuestaListarDepartamentos>> HandleAsync([FromQuery] LlamadaListarDepartamentos request, CancellationToken cancellationToken = default)
        {
            var respuesta = new RespuestaListarDepartamentos(request.CorrelationId);

            var Departamentos = await _repositorio.ListarTodoAsync(cancellationToken);
            if (Departamentos is null) return NotFound();
            respuesta.Departamentos.AddRange(Departamentos.Select(x => _mapper.Map<DepartamentoDto>(x)));
            respuesta.Total = respuesta.Departamentos.Count;

            return Ok(respuesta);
        }
    }
}
