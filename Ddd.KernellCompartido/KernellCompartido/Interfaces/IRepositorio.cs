using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace Ddd.KernellCompartido.Interfaces
{
    public interface IRepositorio<T,Tid> where T : class, IRaizDeAgregado
    {
        Task<T> BuscarPorIdIdAsync(Tid id, CancellationToken tokenDeCancelacion);

        Task<IReadOnlyList<T>> ListarTodoAsync(CancellationToken cancellationToken);

        Task<IReadOnlyList<T>> ListarAsync(ISpecification<T> especificacion);

        Task<T> AgregarAsync(T entidad, CancellationToken tokenDeCancelacion);

        Task ActualizarAsync(T entidad, CancellationToken tokenDeCancelacion);

        Task EliminarAsync(T entidad, CancellationToken tokenDeCancelacion);
    }
}
