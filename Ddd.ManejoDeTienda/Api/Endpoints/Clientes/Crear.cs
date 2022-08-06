using System;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Ddd.KernellCompartido.Interfaces;
using Ddd.ManejoDeTienda.Dominio.Agregados;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebCompartido.Modelos.Cliente;

namespace Api.Endpoints.Clientes
{
    public class Crear : BaseAsyncEndpoint.WithRequest<LlamadaCrearCliente>.WithResponse<RespuestaCrearCliente>
    {
        private IRepositorio<Cliente, Guid> _repositorio;
        private readonly IMapper _mapper;

        public Crear(IRepositorio<Cliente, Guid> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpPost("api/Clientes")]
        [SwaggerOperation(
            Summary = "Crea un nuevo Cliente",
            Description = "Endpoint usado para crear un Cliente",
            OperationId = "Clientes.crear",
            Tags = new[] { "Clientes" }
            )]
        public override async Task<ActionResult<RespuestaCrearCliente>> HandleAsync(LlamadaCrearCliente request, CancellationToken cancellationToken = default)
        {
            var respuesta = new RespuestaCrearCliente(request.CorrelationId);

            var nuevoCliente = _mapper.Map<Cliente>(request);
            nuevoCliente = await _repositorio.AgregarAsync(nuevoCliente, new CancellationToken());

            var dto = _mapper.Map<ClienteDto>(nuevoCliente);
            respuesta.Cliente = dto;

            return Ok(respuesta);
        }
    }
}
