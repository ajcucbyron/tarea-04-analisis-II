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
using WebCompartido.Modelos.Proveedor;

namespace Api.Endpoints.Proveedores
{
    public class Listar : BaseAsyncEndpoint
        .WithRequest<LlamadaListarProveedores>
        .WithResponse<RespuestaListarProveedores>
    {
        private readonly IRepositorio<Proveedor, Guid> _repositorio;
        private readonly IMapper _mapper;

        public Listar(IRepositorio<Proveedor, Guid> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpGet("api/Proveedores")]
        [SwaggerOperation(
            Summary = "Lista los Proveedores existentes",
            Description = "Lista los Proveedores existentes",
            OperationId = "Proveedores.listar",
            Tags = new[] { "Proveedores" }
            )]
        public override async Task<ActionResult<RespuestaListarProveedores>> HandleAsync([FromQuery] LlamadaListarProveedores request, CancellationToken cancellationToken = default)
        {
            var respuesta = new RespuestaListarProveedores(request.CorrelationId);

            var Proveedores = await _repositorio.ListarTodoAsync(cancellationToken);
            if (Proveedores is null) return NotFound();
            respuesta.Proveedores.AddRange(Proveedores.Select(x => _mapper.Map<ProveedorDto>(x)));
            respuesta.Total = respuesta.Proveedores.Count;

            return Ok(respuesta);
        }
    }
}
