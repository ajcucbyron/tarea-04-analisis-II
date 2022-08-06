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
using WebCompartido.Modelos.MateriaPrima;

namespace Api.Endpoints.MateriaPrimas
{
    public class Listar : BaseAsyncEndpoint
        .WithRequest<LlamadaListarMateriasPrimas>
        .WithResponse<RespuestaListarMateriasPrimas>
    {
        private readonly IRepositorio<MateriaPrima, Guid> _repositorio;
        private readonly IMapper _mapper;

        public Listar(IRepositorio<MateriaPrima, Guid> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpGet("api/MateriasPrimas")]
        [SwaggerOperation(
            Summary = "Lista las MateriasPrimas existentes",
            Description = "Lista las MateriasPrimas existentes",
            OperationId = "MateriasPrimas.listar",
            Tags = new[] { "MateriasPrimas" }
            )]
        public override async Task<ActionResult<RespuestaListarMateriasPrimas>> HandleAsync([FromQuery] LlamadaListarMateriaPrimas request, CancellationToken cancellationToken = default)
        {
            var respuesta = new RespuestaListarMateriasPrimas(request.CorrelationId);

            var MateriaPrimas = await _repositorio.ListarTodoAsync(cancellationToken);
            if (MateriaPrimas is null) return NotFound();
            respuesta.MateriasPrimas.AddRange(MateriasPrimas.Select(x => _mapper.Map<MateriaPrimaDto>(x)));
            respuesta.Total = respuesta.MateriasPrimas.Count;

            return Ok(respuesta);
        }
    }
}
