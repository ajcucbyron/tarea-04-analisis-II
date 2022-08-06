using System;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Ddd.KernellCompartido.Interfaces;
using Ddd.ManejoDeTienda.Dominio.Agregados;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebCompartido.Modelos.MateriaPrima;

namespace Api.Endpoints.MateriasPrimas
{
    public class Crear : BaseAsyncEndpoint.WithRequest<LlamadaCrearMateriaPrima>.WithResponse<RespuestaCrearMateriaPrima>
    {
        private IRepositorio<MateriaPrima, Guid> _repositorio;
        private readonly IMapper _mapper;

        public Crear(IRepositorio<MateriaPrima, Guid> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpPost("api/MateriasPrimas")]
        [SwaggerOperation(
            Summary = "Crea una nueva MateriaPrima",
            Description = "Endpoint usado para crear una MateriaPrima",
            OperationId = "MateriasPrimas.crear",
            Tags = new[] { "MateriasPrimas" }
            )]
        public override async Task<ActionResult<RespuestaCrearMateriaPrima>> HandleAsync(LlamadaCrearMateriaPrima request, CancellationToken cancellationToken = default)
        {
            var respuesta = new RespuestaCrearMateriaPrima(request.CorrelationId);

            var nuevoMateriaPrima = _mapper.Map<MateriaPrima>(request);
            nuevoMateriaPrima = await _repositorio.AgregarAsync(nuevoMateriaPrima, new CancellationToken());

            var dto = _mapper.Map<MateriaPrimaDto>(nuevoMateriaPrima);
            respuesta.MateriaPrima = dto;

            return Ok(respuesta);
        }
    }
}
