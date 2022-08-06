using System;
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
    public class Crear : BaseAsyncEndpoint.WithRequest<LlamadaCrearProducto>.WithResponse<RespuestaCrearProducto>
    {
        private IRepositorio<Producto, Guid> _repositorio;
        private readonly IMapper _mapper;

        public Crear(IRepositorio<Producto, Guid> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpPost("api/Productos")]
        [SwaggerOperation(
            Summary = "Crea un nuevo Producto",
            Description = "Endpoint usado para crear un Producto",
            OperationId = "Productos.crear",
            Tags = new[] { "Productos" }
            )]
        public override async Task<ActionResult<RespuestaCrearProducto>> HandleAsync(LlamadaCrearProducto request, CancellationToken cancellationToken = default)
        {
            var respuesta = new RespuestaCrearProducto(request.CorrelationId);

            var nuevoProducto = _mapper.Map<Producto>(request);
            nuevoProducto = await _repositorio.AgregarAsync(nuevoProducto, new CancellationToken());

            var dto = _mapper.Map<ProductoDto>(nuevoProducto);
            respuesta.Producto = dto;

            return Ok(respuesta);
        }
    }
}
