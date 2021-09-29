using Microsoft.EntityFrameworkCore;
using NT.Tasks.Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NT.Tasks.Repository
{
    internal class EntityRepository<T> : IEntityRepository<T> where T : class
    {

        private readonly AppDbContext _context;

        public EntityRepository(AppDbContext context) => _context = context;

        public Task Add(T entity) => _context.Set<T>().AddAsync(entity).AsTask();

        public Task<T> GetById(Guid id, CancellationToken cancellationToken) => _context.Set<T>().FindAsync(new object[] { id }, cancellationToken).AsTask();

        /// <inheritdoc />
        public Task Delete(T entity) => Task.Run(() => _context.Set<T>().Remove(entity));

        /// <inheritdoc />
        public IQueryable<T> Query(Expression<Func<T, bool>> predicate = null) =>
             predicate != null ?
                _context.Set<T>().Where(predicate) :
                _context.Set<T>();

        


        /// <inheritdoc />
        public Task Save(T entity) => Task.Run(() => _context.Update(entity));


        /// <inheritdoc />
        public Task<List<T>> GetAll(CancellationToken cancellationToken) => _context.Set<T>().ToListAsync(cancellationToken);

        /// <inheritdoc />
        public Task<int> Count(Expression<Func<T, bool>> predicate = null, CancellationToken cancellationToken = default) => predicate == null
            ? _context.Set<T>().CountAsync(cancellationToken)
            : _context.Set<T>().CountAsync(predicate, cancellationToken);

       


    }
}
