using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SlimFormaturas.Domain.Interfaces.Repository {
    public interface IRepository<TEntity> where TEntity : class {

        ValueTask<TEntity> GetById(string id);
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task Insert(TEntity obj);
        Task Update(TEntity obj);
        Task Remove(string id);

        Task<IList<TEntity>> GetAll();
        Task<IList<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate);

        Task<int> CountAll();
        Task<int> CountWhere(Expression<Func<TEntity, bool>> predicate);

        void Dispose();
    }
}
