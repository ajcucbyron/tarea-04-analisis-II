using System;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Ddd.KernellCompartido.Interfaces;
using Ddd.ManejoDeTienda.Dominio.Agregados;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebCompartido.Modelos.Pedido;

namespace Api.Endpoints.Pedidos
{
    public class Crear : BaseAsyncEndpoint.WithRequest<LlamadaCrearPedido>.WithResponse<RespuestaCrearPedido>
    {
        private IRepositorio<Pedido, Guid> _repositorio;
        private readonly IMapper _mapper;

        public Crear(IRepositorio<Pedido, Guid> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpPost("api/Pedidos")]
        [SwaggerOperation(
            Summary = "Crea un nuevo Pedido",
            Description = "Endpoint usado para crear un Pedido",
            OperationId = "Pedidos.crear",
            Tags = new[] { "Pedidos" }
            )]
        public override async Task<ActionResult<RespuestaCrearPedido>> HandleAsync(LlamadaCrearPedido request, CancellationToken cancellationToken = default)
        {
            var respuesta = new RespuestaCrearPedido(request.CorrelationId);

            var nuevoPedido = _mapper.Map<Pedido>(request);
            nuevoPedido = await _repositorio.AgregarAsync(nuevoPedido, new CancellationToken());

            var dto = _mapper.Map<PedidoDto>(nuevoPedido);
            respuesta.Pedido = dto;

            return Ok(respuesta);
        }
    }
}
