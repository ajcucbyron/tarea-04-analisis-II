using System;
using System.Collections.Generic;
using Ddd.ManejoDeTienda.WebCompartido.Modelos;

namespace WebCompartido.Modelos.MateriaPrima
{
    public class RespuestaListarMateriasPrimas: RespuestaBase
    {
        public List<MateriaPrimaDto> MateriasPrimas { get; set; } = new List<MateriaPrimaDto>();

        public int Total { get; set; }

        public RespuestaListarMateriasPrimas(Guid correlationId) : base(correlationId)
        {
        }

        public RespuestaListarMateriasPrimas()
        {
        }
    }
}
