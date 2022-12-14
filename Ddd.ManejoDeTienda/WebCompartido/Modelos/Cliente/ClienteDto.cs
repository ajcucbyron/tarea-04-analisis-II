using System;
using System.ComponentModel.DataAnnotations;
namespace WebCompartido.Modelos.Cliente
{
    public class ClienteDto
    {
        [Required]
        public Guid ClienteId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string TelefonoMobil { get; set; }
        public string Titulo { get; set; }
        public Guid TiendaId { get; set; }
        public DateTime FechaDeComienzo { get; set; }
        public DateTime? FechaDeTerminacion { get; set; }
    }
}
