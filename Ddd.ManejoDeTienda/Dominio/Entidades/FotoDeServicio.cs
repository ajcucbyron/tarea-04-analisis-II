using System;
using Ardalis.GuardClauses;
using Ddd.KernellCompartido;

namespace Ddd.ManejoDeTienda.Dominio.Entidades
{
    public class FotoDeServicio: EntidadBase<Guid>
    {
        public Guid TiendaId { get; private set; }
        public Guid ProductoId { get; private set; }
        public DateTime Fecha { get; private set; }
        public Uri ImagenUrl { get; private set; }
        public string Descripcion { get; private set; }

        public FotoDeServicio()
        {

        }
        public FotoDeServicio(Guid ProductoId, DateTime fecha, Uri imageUrl, string descripcion)
        {
            Id = Guid.NewGuid();
            ProductoId = ProductoId;
            Fecha = fecha;
            ImagenUrl = imageUrl;
            Descripcion = descripcion;
        }

        public void ActualizarFecha(DateTime fecha, Action action)
        {
            Fecha = Guard.Against.Default(fecha, nameof(fecha));

            action?.Invoke();
        }

        public void ActualizarDescripcion(string descripcion, Action action)
        {
            Descripcion = Guard.Against.NullOrEmpty(descripcion, nameof(descripcion));

            action?.Invoke();
        }
    }
}
