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
using WebCompartido.Modelos.Municipio;

namespace Api.Endpoints.Municipios
{
    public class Listar : BaseAsyncEndpoint
        .WithRequest<LlamadaListarMunicipios>
        .WithResponse<RespuestaListarMunicipios>
    {
        private readonly IRepositorio<Municipio, Guid> _repositorio;
        private readonly IMapper _mapper;

        public Listar(IRepositorio<Municipio, Guid> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpGet("api/Municipios")]
        [SwaggerOperation(
            Summary = "Lista los Municipios existentes",
            Description = "Lista los Municipios existentes",
            OperationId = "Municipios.listar",
            Tags = new[] { "Municipios" }
            )]
        public override async Task<ActionResult<RespuestaListarMunicipios>> HandleAsync([FromQuery] LlamadaListarMunicipios request, CancellationToken cancellationToken = default)
        {
            var respuesta = new RespuestaListarMunicipios(request.CorrelationId);

            var Municipios = await _repositorio.ListarTodoAsync(cancellationToken);
            if (Municipios is null) return NotFound();
            respuesta.Municipios.AddRange(Municipios.Select(x => _mapper.Map<MunicipioDto>(x)));
            respuesta.Total = respuesta.Municipios.Count;

            return Ok(respuesta);
        }
    }
}
