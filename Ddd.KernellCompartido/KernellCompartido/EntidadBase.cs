namespace Ddd.KernellCompartido
{
    /// <summary>
    /// La entidad base usando el Id otorgado
    /// </summary>
    public abstract class EntidadBase<TId>
    {
        public TId Id { get; set; }        
    }
}
