using System;
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
    public class Crear : BaseAsyncEndpoint.WithRequest<LlamadaCrearVehiculo>.WithResponse<RespuestaCrearVehiculo>
    {
        private IRepositorio<Vehiculo, Guid> _repositorio;
        private readonly IMapper _mapper;

        public Crear(IRepositorio<Vehiculo, Guid> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpPost("api/Vehiculos")]
        [SwaggerOperation(
            Summary = "Crea un nuevo Vehiculo",
            Description = "Endpoint usado para crear un Vehiculo",
            OperationId = "Vehiculos.crear",
            Tags = new[] { "Vehiculos" }
            )]
        public override async Task<ActionResult<RespuestaCrearVehiculo>> HandleAsync(LlamadaCrearVehiculo request, CancellationToken cancellationToken = default)
        {
            var respuesta = new RespuestaCrearVehiculo(request.CorrelationId);

            var nuevoVehiculo = _mapper.Map<Vehiculo>(request);
            nuevoVehiculo = await _repositorio.AgregarAsync(nuevoVehiculo, new CancellationToken());

            var dto = _mapper.Map<VehiculoDto>(nuevoVehiculo);
            respuesta.Vehiculo = dto;

            return Ok(respuesta);
        }
    }
}
