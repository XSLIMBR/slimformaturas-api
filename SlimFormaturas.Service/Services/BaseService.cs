using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Domain.Interfaces.Service;

namespace SlimFormaturas.Service.Services {
    public class BaseService<TEntity> : IDisposable, IService<TEntity> where TEntity : class{
        private readonly IRepository<TEntity> _repository;

        public BaseService(IRepository<TEntity> repository) {
            _repository = repository;
        }

        public async Task<TEntity> Post<TVEntity>(TEntity obj) where TVEntity : AbstractValidator<TEntity> {
            Validate(obj, Activator.CreateInstance<TVEntity>());
            await _repository.Insert(obj);
            return obj;
        }

        public async Task<TEntity> Put<TVEntity>(TEntity obj) where TVEntity : AbstractValidator<TEntity> {
            Validate(obj, Activator.CreateInstance<TVEntity>());
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

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator) {
            if (obj == null)
                throw new Exception("Registros não detectados!");
            validator.ValidateAndThrow(obj);
        }

        public void Dispose() {
            _repository.Dispose();
        }
    }
}
