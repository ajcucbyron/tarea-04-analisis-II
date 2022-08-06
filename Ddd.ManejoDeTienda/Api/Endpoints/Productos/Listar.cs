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
using WebCompartido.Modelos.Producto;

namespace Api.Endpoints.Productos
{
    public class Listar : BaseAsyncEndpoint
        .WithRequest<LlamadaListarProductos>
        .WithResponse<RespuestaListarProductos>
    {
        private readonly IRepositorio<Producto, Guid> _repositorio;
        private readonly IMapper _mapper;

        public Listar(IRepositorio<Producto, Guid> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpGet("api/Productos")]
        [SwaggerOperation(
            Summary = "Lista los Productos existentes",
            Description = "Lista los Productos existentes",
            OperationId = "Productos.listar",
            Tags = new[] { "Productos" }
            )]
        public override async Task<ActionResult<RespuestaListarProductos>> HandleAsync([FromQuery] LlamadaListarProductos request, CancellationToken cancellationToken = default)
        {
            var respuesta = new RespuestaListarProductos(request.CorrelationId);

            var Productos = await _repositorio.ListarTodoAsync(cancellationToken);
            if (Productos is null) return NotFound();
            respuesta.Productos.AddRange(Productos.Select(x => _mapper.Map<ProductoDto>(x)));
            respuesta.Total = respuesta.Productos.Count;

            return Ok(respuesta);
        }
    }
}
