using System;
using Ddd.ManejoDeTienda.WebCompartido.Modelos;

namespace WebCompartido.Modelos.Empleado
{
    public class LlamadaCrearEmpleado: LLamadaBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string TelefonoMobil { get; set; }
        public string Titulo { get; set; }
        public Guid TiendaId { get; set; }
        public DateTime FechaDeComienzo { get; set; }        
    }
}
