using System;
using System.Collections.Generic;
using System.Text;

namespace SlimFormaturas.Domain.Interfaces.Repository {
    public interface IRepository<TEntity> where TEntity : class {
        void Insert(TEntity obj);
        TEntity GetById(string id);
        IList<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(string id);
        void Dispose();
    }
}
