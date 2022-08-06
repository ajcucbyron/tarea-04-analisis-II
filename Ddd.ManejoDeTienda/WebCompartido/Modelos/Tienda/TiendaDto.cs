using System;
using System.ComponentModel.DataAnnotations;

namespace Ddd.ManejoDeTienda.WebCompartido.Modelos.Tienda
{
    public class TiendaDto
    {
        public Guid TiendaId { get; set; }

        [Required(ErrorMessage = "El nombre legal es requerido!")]
        public string NombreLegal { get; set; }

        [Required(ErrorMessage = "El nombre es requerido!")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La linea de direccion 1 es requerid1!")]
        public string LineaDeDireccion1 { get; set; }
        public string LineaDeDireccion2 { get; set; }

        [Required(ErrorMessage = "El pais es requerido!")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "La provincia o estado es requerido!")]
        public string ProvinciaEstadoDepartamento { get; set; }

        [Required(ErrorMessage = "La ciudad es requerida!")]
        public string Ciudad { get; set; }
    }
}
