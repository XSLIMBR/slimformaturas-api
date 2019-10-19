using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;

namespace SlimFormaturas.Service.Services {
    public class BaseService<TEntity> : IDisposable, IService<TEntity> where TEntity : class{
        private readonly IRepository<TEntity> _repository;
        protected readonly NotificationHandler _notifications;

        public BaseService(
            IRepository<TEntity> repository,
            NotificationHandler notifications) {
            _repository = repository;
            _notifications = notifications;
        }

        public async Task<TEntity> Post<TVEntity>(TEntity obj) where TVEntity : AbstractValidator<TEntity> {
            _notifications.AddNotifications(await Validate(obj, Activator.CreateInstance<TVEntity>()));
            if (!_notifications.HasNotifications){
                await _repository.Insert(obj);
            }
            return obj;
        }

        public async Task<TEntity> Put<TVEntity>(TEntity obj) where TVEntity : AbstractValidator<TEntity> {
            _notifications.AddNotifications(await Validate(obj, Activator.CreateInstance<TVEntity>()));
            if(!_notifications.HasNotifications){
                await _repository.Update(obj);
            }
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

        private async Task<ValidationResult> Validate(TEntity obj, AbstractValidator<TEntity> validator) {
            if (obj == null)
                throw new Exception("Registros não detectados!");
            return await validator.ValidateAsync(obj);
        }

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
