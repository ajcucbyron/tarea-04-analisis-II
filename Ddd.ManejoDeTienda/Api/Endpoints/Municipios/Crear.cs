using System;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Ddd.KernellCompartido.Interfaces;
using Ddd.ManejoDeTienda.Dominio.Agregados;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebCompartido.Modelos.Municipio;

namespace Api.Endpoints.Municipios
{
    public class Crear : BaseAsyncEndpoint.WithRequest<LlamadaCrearMunicipio>.WithResponse<RespuestaCrearMunicipio>
    {
        private IRepositorio<Municipio, Guid> _repositorio;
        private readonly IMapper _mapper;

        public Crear(IRepositorio<Municipio, Guid> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpPost("api/Municipios")]
        [SwaggerOperation(
            Summary = "Crea un nuevo Municipio",
            Description = "Endpoint usado para crear un Municipio",
            OperationId = "Municipios.crear",
            Tags = new[] { "Municipios" }
            )]
        public override async Task<ActionResult<RespuestaCrearMunicipio>> HandleAsync(LlamadaCrearMunicipio request, CancellationToken cancellationToken = default)
        {
            var respuesta = new RespuestaCrearMunicipio(request.CorrelationId);

            var nuevoMunicipio = _mapper.Map<Municipio>(request);
            nuevoMunicipio = await _repositorio.AgregarAsync(nuevoMunicipio, new CancellationToken());

            var dto = _mapper.Map<MunicipioDto>(nuevoMunicipio);
            respuesta.Municipio = dto;

            return Ok(respuesta);
        }
    }
}
