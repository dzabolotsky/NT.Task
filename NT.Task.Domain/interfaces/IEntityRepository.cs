using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace NT.Tasks.Domain.interfaces
{


    public interface IEntityRepository<T> where T : class
    {


        IQueryable<T> Query(Expression<Func<T, bool>> predicate = null);


        Task<T> GetById(Guid id, CancellationToken cancellationToken = default);


        Task Add(T entity);


        Task Delete(T entity);


        Task Save(T entity);


        Task<List<T>> GetAll(CancellationToken cancellationToken = default);


        Task<int> Count(Expression<Func<T, bool>> predicate = null, CancellationToken cancellationToken = default);


       
    }
}
