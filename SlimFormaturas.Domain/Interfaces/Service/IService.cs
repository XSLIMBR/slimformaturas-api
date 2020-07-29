using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SlimFormaturas.Domain.Entities;

namespace SlimFormaturas.Domain.Interfaces.Service {
    public interface IService<TEntity> where TEntity : class {
        //Task<TEntity> Post<TVEntity>(TEntity obj) where TVEntity : AbstractValidator<TEntity>;
        Task<TEntity> Post(TEntity obj);
        Task<TEntity> Put(TEntity obj);
        Task Delete(string id);
        Task<TEntity> Get(string id);
        Task<IList<TEntity>> Get();

        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<IList<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate);
        Task<int> CountAll();
        Task<int> CountWhere(Expression<Func<TEntity, bool>> predicate);

        PaginatedList<TEntity> PaginatedList(IList<TEntity> source, int pageIndex, int pageSize);

        void Dispose();
    }
}
