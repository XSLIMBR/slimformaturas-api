using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Infra.Data.Context;


namespace SlimFormaturas.Infra.Data.Repository {
    public class BaseRepository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class {

        protected readonly MssqlContext Context;

        public BaseRepository(MssqlContext context) {
            Context = context;
        }
        public async ValueTask<TEntity> GetById(string id) => await Context.Set<TEntity>().FindAsync(id);
        public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate) => await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);

        public async Task Insert(TEntity obj) {
            await Context.Set<TEntity>().AddAsync(obj);
            await Context.SaveChangesAsync();
        }
        public async Task<int> Update(TEntity obj) {
            Context.Set<TEntity>().Update(obj);
            return await Context.SaveChangesAsync();
        }

        public async Task<int> Remove(string id) {
            Context.Set<TEntity>().Remove(await Context.Set<TEntity>().FindAsync(id));
            return await Context.SaveChangesAsync();
        }

        public async Task<IList<TEntity>> GetAll() {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<IList<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate) {
            return await Context.Set<TEntity>().Where(predicate).ToListAsync();
        }
 
        public async Task<int> CountAll() => await Context.Set<TEntity>().CountAsync();
 
        public async Task<int> CountWhere(Expression<Func<TEntity, bool>> predicate) => await Context.Set<TEntity>().CountAsync(predicate);

        public void Dispose() {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
