using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;

namespace SlimFormaturas.Service.Services {
    public class TypeGenericService : BaseService<TypeGeneric>, ITypeGenericService {
         readonly ITypeGenericRepository _typeGenericRepository;
        protected readonly NotificationHandler _notifications;

        public TypeGenericService(
            ITypeGenericRepository typeGenericRepository,
             NotificationHandler notifications
            ) : base(typeGenericRepository) {
            _typeGenericRepository = typeGenericRepository;
            _notifications = notifications;
        }

        public async Task<TypeGeneric> Insert(TypeGeneric obj) {
            TypeGeneric typeGeneric = new TypeGeneric();
            if (typeGeneric.Valid) {
                await Post(typeGeneric);
            } else {
                _notifications.AddNotifications(typeGeneric.ValidationResult);
            }

            return typeGeneric;
        }

        public async Task<TypeGeneric> Update(TypeGeneric obj) {
            TypeGeneric typeGeneric = new TypeGeneric();
            if (typeGeneric.Valid) {
                await Put(typeGeneric);
            } else {
                _notifications.AddNotifications(typeGeneric.ValidationResult);
            }

            return typeGeneric;
        }
    }
}
