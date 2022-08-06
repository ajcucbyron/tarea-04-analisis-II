using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using Ddd.KernellCompartido;
using Ddd.KernellCompartido.Interfaces;
using Ddd.ManejoDeTienda.Dominio.Entidades;

namespace Ddd.ManejoDeTienda.Dominio.Agregados
{
    /// <summary>
    /// Un agregado sencillo que no tiene otras entidades. 
    /// </summary>
    public class Empleado : EntidadBase<Guid>, IRaizDeAgregado
    {

        public string PrimerNombre { get; private set; }
        public string Apellido { get; private set; }
        public string Email { get; private set; }
        public string TelefonoMobil { get; private set; }
        public string Titulo { get; private set; }
        public Guid TiendaId { get; private set; }
        public DateTime FechaDeComienzo { get; private set; }
        public DateTime? FechaDeTerminacion { get; private set; }

        private readonly List<FotoDeServicio> _fotosDeServicio = new List<FotoDeServicio>();
        public IEnumerable<FotoDeServicio> FotosDeServicio => _fotosDeServicio.AsReadOnly();

        public Empleado()
        {

        }

        public Empleado(Guid tiendaId, string primerNombre, string apellido, string telefono,
            string email, string titulo, DateTime fechaDeComienzo, DateTime? fechaDeTerminacion = null)
        {
            Id = Guid.NewGuid();
            TiendaId = Guard.Against.Default(tiendaId, nameof(tiendaId));
            PrimerNombre = Guard.Against.NullOrEmpty(primerNombre, nameof(primerNombre));
            Apellido = Guard.Against.NullOrEmpty(apellido, nameof(apellido)); ;
            TelefonoMobil = Guard.Against.NullOrEmpty(telefono, nameof(telefono));
            Email = Guard.Against.NullOrEmpty(email, nameof(email));
            Titulo = Guard.Against.NullOrEmpty(titulo, nameof(titulo));
            FechaDeComienzo = Guard.Against.Default(fechaDeComienzo, nameof(fechaDeComienzo));

            if (fechaDeTerminacion != null)
                TerminarEmpleado((DateTime)fechaDeTerminacion);
        }

        public void ActualizarTienda(Guid tiendaId, Action funcion = null)
        {

            TiendaId = Guard.Against.Default(tiendaId, nameof(tiendaId));

            funcion?.Invoke();
            
        }

        public void TerminarEmpleado(DateTime fechaDeTerminacion, Action funcion = null)
        {
            FechaDeTerminacion = Guard.Against.OutOfRange(fechaDeTerminacion, nameof(fechaDeTerminacion), FechaDeComienzo, DateTime.Now);

            funcion?.Invoke();

        }

        public bool IsActive()
        {
            return FechaDeTerminacion == null;
        }

        public void CambiarTitulo(string titulo, Action funcion = null)
        {
            Titulo = Guard.Against.NullOrEmpty(titulo, nameof(titulo));
            funcion?.Invoke();
        }

        public void ActualizarPerfil(string primerNombre, string apellido, string telefono, string email, string titulo, Action funcion = null)
        {
            PrimerNombre = Guard.Against.NullOrEmpty(primerNombre, nameof(primerNombre));
            Apellido = Guard.Against.NullOrEmpty(apellido, nameof(apellido)); ;
            TelefonoMobil = Guard.Against.NullOrEmpty(telefono, nameof(telefono));
            Email = Guard.Against.NullOrEmpty(email, nameof(email));
            Titulo = Guard.Against.NullOrEmpty(titulo, nameof(titulo));
            funcion?.Invoke();
        }

        public void AgregarFotoDeServicio(FotoDeServicio fotoDeServicio, Action funcion = null)
        {
            //agregar invariantes para asegurarse que foto no existe. por ejemplo buscar URL
            var fotoExiste = _fotosDeServicio.Any(f => f.ImagenUrl == fotoDeServicio.ImagenUrl);
            if (fotoExiste)
                throw new ArgumentException($"La foto ya existe...o algo asi");

            _fotosDeServicio.Add(fotoDeServicio);
            funcion?.Invoke();
        }

        public void EliminarFotoDeServicio(Guid id, Action funcion = null)
        {
            //agregar invariantes para asegurarse que foto no existe. por ejemplo buscar URL
            var fotoDeServicio = _fotosDeServicio.FirstOrDefault(f => f.Id == id);
            if (fotoDeServicio == null)
                throw new ArgumentException($"La foto NO existe...o algo asi");

            _fotosDeServicio.Remove(fotoDeServicio);
            funcion?.Invoke();
        }

        public void EliminarTodasLasFotosDeServicio(Action funcion = null)
        {
            _fotosDeServicio.Clear();
            funcion?.Invoke();
        }
    }
}
