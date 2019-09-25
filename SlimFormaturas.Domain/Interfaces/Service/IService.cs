using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace SlimFormaturas.Domain.Interfaces.Service {
    public interface IService<TEntity> where TEntity : class {
        Task<TEntity> Post<TVEntity>(TEntity obj) where TVEntity : AbstractValidator<TEntity>;
        Task<TEntity>  Put<TVEntity>(TEntity obj) where TVEntity : AbstractValidator<TEntity>;
        Task Delete(string id);
        Task<TEntity> Get(string id);
        Task<IList<TEntity>> Get();
        void Dispose();
    }
}
