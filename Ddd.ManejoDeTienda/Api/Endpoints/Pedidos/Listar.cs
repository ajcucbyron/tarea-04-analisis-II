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
using WebCompartido.Modelos.Pedido;

namespace Api.Endpoints.Pedidos
{
    public class Listar : BaseAsyncEndpoint
        .WithRequest<LlamadaListarPedidos>
        .WithResponse<RespuestaListarPedidos>
    {
        private readonly IRepositorio<Pedido, Guid> _repositorio;
        private readonly IMapper _mapper;

        public Listar(IRepositorio<Pedido, Guid> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpGet("api/Pedidos")]
        [SwaggerOperation(
            Summary = "Lista los Pedidos existentes",
            Description = "Lista los Pedidos existentes",
            OperationId = "Pedidos.listar",
            Tags = new[] { "Pedidos" }
            )]
        public override async Task<ActionResult<RespuestaListarPedidos>> HandleAsync([FromQuery] LlamadaListarPedidos request, CancellationToken cancellationToken = default)
        {
            var respuesta = new RespuestaListarPedidos(request.CorrelationId);

            var Pedidos = await _repositorio.ListarTodoAsync(cancellationToken);
            if (Pedidos is null) return NotFound();
            respuesta.Pedidos.AddRange(Pedidos.Select(x => _mapper.Map<PedidoDto>(x)));
            respuesta.Total = respuesta.Pedidos.Count;

            return Ok(respuesta);
        }
    }
}
