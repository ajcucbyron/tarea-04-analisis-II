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
using WebCompartido.Modelos.Vehiculo;

namespace Api.Endpoints.Vehiculos
{
    public class Listar : BaseAsyncEndpoint
        .WithRequest<LlamadaListarVehiculos>
        .WithResponse<RespuestaListarVehiculos>
    {
        private readonly IRepositorio<Vehiculo, Guid> _repositorio;
        private readonly IMapper _mapper;

        public Listar(IRepositorio<Vehiculo, Guid> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpGet("api/Vehiculos")]
        [SwaggerOperation(
            Summary = "Lista los Vehiculos existentes",
            Description = "Lista los Vehiculos existentes",
            OperationId = "Vehiculos.listar",
            Tags = new[] { "Vehiculos" }
            )]
        public override async Task<ActionResult<RespuestaListarVehiculos>> HandleAsync([FromQuery] LlamadaListarVehiculos request, CancellationToken cancellationToken = default)
        {
            var respuesta = new RespuestaListarVehiculos(request.CorrelationId);

            var Vehiculos = await _repositorio.ListarTodoAsync(cancellationToken);
            if (Vehiculos is null) return NotFound();
            respuesta.Vehiculos.AddRange(Vehiculos.Select(x => _mapper.Map<VehiculoDto>(x)));
            respuesta.Total = respuesta.Vehiculos.Count;

            return Ok(respuesta);
        }
    }
}
