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
using WebCompartido.Modelos.Cliente;

namespace Api.Endpoints.Clientes
{
    public class Listar : BaseAsyncEndpoint
        .WithRequest<LlamadaListarClientes>
        .WithResponse<RespuestaListarClientes>
    {
        private readonly IRepositorio<Cliente, Guid> _repositorio;
        private readonly IMapper _mapper;

        public Listar(IRepositorio<Cliente, Guid> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpGet("api/Clientes")]
        [SwaggerOperation(
            Summary = "Lista los Clientes existentes",
            Description = "Lista los Clientes existentes",
            OperationId = "Clientes.listar",
            Tags = new[] { "Clientes" }
            )]
        public override async Task<ActionResult<RespuestaListarClientes>> HandleAsync([FromQuery] LlamadaListarClientes request, CancellationToken cancellationToken = default)
        {
            var respuesta = new RespuestaListarClientes(request.CorrelationId);

            var Clientes = await _repositorio.ListarTodoAsync(cancellationToken);
            if (Clientes is null) return NotFound();
            respuesta.Clientes.AddRange(Clientes.Select(x => _mapper.Map<ClienteDto>(x)));
            respuesta.Total = respuesta.Clientes.Count;

            return Ok(respuesta);
        }
    }
}
