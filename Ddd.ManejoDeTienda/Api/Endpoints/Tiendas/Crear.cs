using System;
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
    public class Crear : BaseAsyncEndpoint.WithRequest<LlamadaCrearTienda>.WithResponse<RespuestaCrearTienda>
    {

        private IRepositorio<Tienda, Guid> _repositorio;
        private readonly IMapper _mapper;

        public Crear(IRepositorio<Tienda, Guid> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpPost("api/tiendas")]
        [SwaggerOperation(
            Summary = "Crea una nueva tienda",
            Description = "Endpoint usado para crear una tienda",
            OperationId = "tiendas.crear",
            Tags = new[] { "Tiendas" }            
            )]
        public override async Task<ActionResult<RespuestaCrearTienda>> HandleAsync(LlamadaCrearTienda request, CancellationToken cancellationToken = default)
        {
            var respuesta = new RespuestaCrearTienda(request.CorrelationId);

            var nuevaTienda = _mapper.Map<Tienda>(request);
            nuevaTienda = await _repositorio.AgregarAsync(nuevaTienda, new CancellationToken());

            var dto = _mapper.Map<TiendaDto>(nuevaTienda);
            respuesta.Tienda = dto;

            return Ok(respuesta);
        }
    }
}
