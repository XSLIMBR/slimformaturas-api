using System;
using System.Collections.Generic;
using System.Linq;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Infra.Data.Context;


namespace SlimFormaturas.Infra.Data.Repository {
    public class BaseRepository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class {

        protected readonly MssqlContext Context;

        public BaseRepository(MssqlContext context) {
            Context = context;
        }

        public IList<TEntity> GetAll() {
            return Context.Set<TEntity>().ToList();
        }

        public TEntity GetById(string id) {
            return Context.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity obj) {
            Context.Set<TEntity>().Add(obj);
            Context.SaveChanges();
        }

        public void Remove(string id) {
            Context.Set<TEntity>().Remove(Context.Set<TEntity>().Find(id));
            Context.SaveChanges();
        }

        public void Update(TEntity obj) {
            Context.Set<TEntity>().Update(obj);
            Context.SaveChanges();
        }

        public void Dispose() {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
