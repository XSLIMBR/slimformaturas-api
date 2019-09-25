using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Infra.Data.Context;


namespace SlimFormaturas.Infra.Data.Repository {
    public class BaseRepository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class {

        protected readonly MssqlContext Context;

        public BaseRepository(MssqlContext context) {
            Context = context;
        }
        public Task<TEntity> GetById(string id) => Context.Set<TEntity>().FindAsync(id);
        public Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate) => Context.Set<TEntity>().FirstOrDefaultAsync(predicate);

        public async Task Insert(TEntity obj) {
            await Context.Set<TEntity>().AddAsync(obj);
            await Context.SaveChangesAsync();
        }
        public  Task Update(TEntity obj) {
            Context.Set<TEntity>().Update(obj);
            return Context.SaveChangesAsync();
        }

        public Task Remove(string id) {
            Context.Set<TEntity>().Remove(Context.Set<TEntity>().Find(id));
            return Context.SaveChangesAsync();
        }

        public async Task<IList<TEntity>> GetAll() {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<IList<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate) {
            return await Context.Set<TEntity>().Where(predicate).ToListAsync();
        }
 
        public Task<int> CountAll() => Context.Set<TEntity>().CountAsync();
 
        public Task<int> CountWhere(Expression<Func<TEntity, bool>> predicate) => Context.Set<TEntity>().CountAsync(predicate);

        public void Dispose() {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
