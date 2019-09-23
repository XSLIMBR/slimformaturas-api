using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Domain.Interfaces.Service;

namespace SlimFormaturas.Service.Services {
    public class BaseService<TEntity> : IDisposable, IService<TEntity> where TEntity : class{
        private readonly IRepository<TEntity> _repository;

        public BaseService(IRepository<TEntity> repository) {
            _repository = repository;
        }

        public TEntity Post<TVEntity>(TEntity obj) where TVEntity : AbstractValidator<TEntity> {
            Validate(obj, Activator.CreateInstance<TVEntity>());
            _repository.Insert(obj);
            return obj;
        }

        public TEntity Put<TVEntity>(TEntity obj) where TVEntity : AbstractValidator<TEntity> {
            Validate(obj, Activator.CreateInstance<TVEntity>());
            _repository.Update(obj);
            return obj;
        }

        public void Delete(string id) {
            if (id == null)
                throw new ArgumentException("O ID não pode ser vazio!");
            _repository.Remove(id);
        }

        public TEntity Get(string id) {
            if (id == null)
                throw new ArgumentException("O ID não pode ser vazio!");
            return _repository.GetById(id);
        }

        public IList<TEntity> Get() => _repository.GetAll();

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator) {
            if (obj == null)
                throw new Exception("Registros não detectados!");
            validator.ValidateAndThrow(obj);
        }

        public void Dispose() {
            _repository.Dispose();
            //GC.SuppressFinalize(this);
        }
    }
}
