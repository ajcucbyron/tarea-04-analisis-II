namespace Ddd.ManejoDeTienda.WebCompartido.Modelos.Tienda
{
    public class LlamadaCrearTienda: LLamadaBase
    {
        public string Nombre { get; set; }
        public string NombreLegal { get; set; }

        public string LineaDeDireccion1 { get; set; }
        public string LineaDeDireccion2 { get; set; }
        public string Pais { get; set; }
        public string ProvinciaEstadoDepartamento { get; set; }
        public string Ciudad { get; set; }
    }
}
