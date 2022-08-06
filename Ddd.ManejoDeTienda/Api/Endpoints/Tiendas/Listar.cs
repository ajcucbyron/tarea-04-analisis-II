using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Ddd.KernellCompartido.Interfaces;
using Ddd.ManejoDeTienda.Dominio.Agregados;
using Ddd.ManejoDeTienda.WebCompartido.Modelos.Tienda;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Endpoints.Tiendas
{
    public class Listar : BaseAsyncEndpoint
        .WithRequest<LlamadaListarTiendas>
        .WithResponse<RespuestaListarTiendas>
    {
        private readonly IRepositorio<Tienda, Guid> _repositorio;
        private readonly IMapper _mapper;

        public Listar(IRepositorio<Tienda, Guid> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpGet("api/tiendas")]
        [SwaggerOperation(
            Summary = "Lista las tiendas existentes",
            Description = "Lista las tiendas existentes",
            OperationId = "tiendas.listar",
            Tags = new[] { "Tiendas" }
            )]
        public override async Task<ActionResult<RespuestaListarTiendas>> HandleAsync([FromQuery]LlamadaListarTiendas request, CancellationToken cancellationToken = default)
        {
            var respuesta = new RespuestaListarTiendas(request.CorrelationId);

            var tiendas = await _repositorio.ListarTodoAsync(cancellationToken);
            if (tiendas is null) return NotFound();
            respuesta.Tiendas.AddRange(tiendas.Select(x=> _mapper.Map<TiendaDto>(x)));
            respuesta.Total = respuesta.Tiendas.Count;

            return Ok(respuesta);
        }
    }
}
