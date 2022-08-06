using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Ddd.KernellCompartido;
using Ddd.KernellCompartido.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.SQL.Data
{
    public class RepositorioBase<T,TId>: IRepositorio<T,TId> where T : EntidadBase<Guid>,IRaizDeAgregado
        
    {
        protected readonly AppDbContext _dbContext;

        public RepositorioBase(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ActualizarAsync(T entidad, CancellationToken tokenDeCancelacion)
        {
            _dbContext.Entry(entidad).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(tokenDeCancelacion);            
        }

        public async Task<T> AgregarAsync(T entidad, CancellationToken tokenDeCancelacion)
        {
            await _dbContext.Set<T>().AddAsync(entidad, tokenDeCancelacion);
            await _dbContext.SaveChangesAsync(tokenDeCancelacion);

            return entidad;
        }

        public async Task<T> BuscarPorIdIdAsync(TId id, CancellationToken tokenDeCancelacion)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(a => a.Id.ToString() == id.ToString(), tokenDeCancelacion); ;
        }


        public async Task EliminarAsync(T entidad, CancellationToken tokenDeCancelacion)
        {
            _dbContext.Set<T>().Remove(entidad);
            await _dbContext.SaveChangesAsync(tokenDeCancelacion);
        }

        public async Task<IReadOnlyList<T>> ListarTodoAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        Task<IReadOnlyList<T>> IRepositorio<T, TId>.ListarAsync(ISpecification<T> especificacion)
        {
            throw new NotImplementedException();
        }
    }
}
