using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SlimFormaturas.Service.Services
{
    public class BaseService<TEntity> : IDisposable, IService<TEntity> where TEntity : class{
         readonly IRepository<TEntity> _repository;
        

        public BaseService(
            IRepository<TEntity> repository) {
            _repository = repository;
        }

        public async Task<TEntity> Post(TEntity obj) {
            await _repository.Insert(obj);
                return obj;
        }

        public async Task<TEntity> Put(TEntity obj){
            await _repository.Update(obj);
                return obj;
        }

        public async Task Delete(string id) {
            if (id == null)
                throw new ArgumentException("O ID não pode ser vazio!");
            await _repository.Remove(id);
        }

        public async Task<TEntity> Get(string id) {
            if (id == null)
                throw new ArgumentException("O ID não pode ser vazio!");
            return await _repository.GetById(id);
        }

        public async Task<IList<TEntity>> Get() => await _repository.GetAll();


        public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate) {
            return await _repository.FirstOrDefault(predicate);  
        }

        public async Task<IList<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate) {
            return await _repository.GetWhere(predicate);
        }
 
        public async Task<int> CountAll() => await _repository.CountAll();
 
        public async Task<int> CountWhere(Expression<Func<TEntity, bool>> predicate) => await _repository.CountWhere(predicate);

        public void Dispose() {
            _repository.Dispose();
        }
    }
}
