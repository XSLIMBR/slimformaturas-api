using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SlimFormaturas.Domain.Interfaces.Service {
    public interface IService<TEntity> where TEntity : class {
        TEntity Post<TVEntity>(TEntity obj) where TVEntity : AbstractValidator<TEntity>;
        TEntity Put<TVEntity>(TEntity obj) where TVEntity : AbstractValidator<TEntity>;
        void Delete(string id);
        TEntity Get(string id);
        IList<TEntity> Get();
        void Dispose();
    }
}
