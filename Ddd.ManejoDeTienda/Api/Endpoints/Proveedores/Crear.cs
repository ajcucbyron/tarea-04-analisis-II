using System;
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
    public class Crear : BaseAsyncEndpoint.WithRequest<LlamadaCrearProveedor>.WithResponse<RespuestaCrearProveedor>
    {
        private IRepositorio<Proveedor, Guid> _repositorio;
        private readonly IMapper _mapper;

        public Crear(IRepositorio<Proveedor, Guid> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpPost("api/Proveedores")]
        [SwaggerOperation(
            Summary = "Crea un nuevo Proveedor",
            Description = "Endpoint usado para crear un Proveedor",
            OperationId = "Proveedores.crear",
            Tags = new[] { "Proveedores" }
            )]
        public override async Task<ActionResult<RespuestaCrearProveedor>> HandleAsync(LlamadaCrearProveedor request, CancellationToken cancellationToken = default)
        {
            var respuesta = new RespuestaCrearProveedor(request.CorrelationId);

            var nuevoProveedor = _mapper.Map<Proveedor>(request);
            nuevoProveedor = await _repositorio.AgregarAsync(nuevoProveedor, new CancellationToken());

            var dto = _mapper.Map<ProveedorDto>(nuevoProveedor);
            respuesta.Proveedor = dto;

            return Ok(respuesta);
        }
    }
}
