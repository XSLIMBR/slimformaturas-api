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
        protected readonly NotificationHandler Notifications;

        public TypeGenericService(
            ITypeGenericRepository typeGenericRepository,
             NotificationHandler notifications
            ) : base(typeGenericRepository) {
            _typeGenericRepository = typeGenericRepository;
            Notifications = notifications;
        }

        public async Task<TypeGeneric> Insert(TypeGeneric obj) {
            TypeGeneric typeGeneric = new TypeGeneric(obj.TypeGenericId, obj.Name, obj.Localization);
            if (typeGeneric.Valid) {
                await Post(typeGeneric);
            } else {
                Notifications.AddNotifications(typeGeneric.ValidationResult);
            }

            return typeGeneric;
        }

        public async Task<TypeGeneric> Update(TypeGeneric obj) {
            TypeGeneric typeGeneric = new TypeGeneric();
            if (typeGeneric.Valid) {
                await Put(typeGeneric);
            } else {
                Notifications.AddNotifications(typeGeneric.ValidationResult);
            }

            return typeGeneric;
        }
    }
}
