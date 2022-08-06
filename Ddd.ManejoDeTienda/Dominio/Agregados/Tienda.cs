using System;
using Ddd.KernellCompartido;
using Ardalis.GuardClauses;
using Ddd.KernellCompartido.Interfaces;


namespace Ddd.ManejoDeTienda.Dominio.Agregados
{
    public class Tienda: EntidadBase<Guid>, IRaizDeAgregado
    {
        /// <summary>
        /// El nombre con que fue registrada la compania para efectos legales
        /// </summary>
        public string NombreLegal { get; private set; }

        /// <summary>
        /// El nombre de la tienda. Este es el nombre con el que se conoce a ala tienda segun los expertos del dominio
        /// </summary>
        public string Nombre { get; private set; }

        public string LineaDeDireccion1 { get; private set; }
        public string LineaDeDireccion2 { get; private set; }
        public string Pais { get; private set; }
        public string ProvinciaEstadoDepartamento { get; private set; }
        public string Ciudad { get; private set; }

        public Tienda(string nombreLegal, string nombre, string lineaDeDireccion1, string lineaDeDireccion2, string pais, string provinciaEstadoDepartamento, string ciudad)
        {
            Id = Guid.NewGuid();
            NombreLegal =  Guard.Against.NullOrEmpty(nombreLegal, nameof(nombreLegal));
            Nombre = Guard.Against.NullOrEmpty(nombre, nameof(nombre));
            LineaDeDireccion1 = Guard.Against.NullOrEmpty(lineaDeDireccion1, nameof(lineaDeDireccion1));
            LineaDeDireccion2 = lineaDeDireccion2;
            Pais = Guard.Against.NullOrEmpty(pais, nameof(pais));
            ProvinciaEstadoDepartamento = Guard.Against.NullOrEmpty(provinciaEstadoDepartamento, nameof(provinciaEstadoDepartamento));
            Ciudad = Guard.Against.NullOrEmpty(ciudad, nameof(ciudad));
        }

        public void CambiarNombreLegal(string nombreLegal, Action funcion = null)
        {
            NombreLegal = Guard.Against.NullOrEmpty(nombreLegal, nameof(nombreLegal));
            funcion?.Invoke();
        }

        public void CambiarNombre(string nombre, Action funcion = null)
        {
            Nombre = Guard.Against.NullOrEmpty(nombre, nameof(nombre));
            funcion?.Invoke();
        }

        public void CambiarDireccion(string lineaDeDireccion1, string lineaDeDireccion2, string pais, string provincia, string ciudad)
        {
            LineaDeDireccion1 = Guard.Against.NullOrEmpty(lineaDeDireccion1, nameof(lineaDeDireccion1));
            LineaDeDireccion2 = lineaDeDireccion2;
            Pais = Guard.Against.NullOrEmpty(pais, nameof(pais));
            ProvinciaEstadoDepartamento = Guard.Against.NullOrEmpty(provincia, nameof(provincia));
            Ciudad = Guard.Against.NullOrEmpty(ciudad, nameof(ciudad));
        }
    }
}
