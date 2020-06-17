using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SlimFormaturas.Domain.Dto.TypeGeneric;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using SlimFormaturas.Domain.Validators;

namespace SlimFormaturas.Service.Services {
    public class TypeGenericService : BaseService<TypeGeneric>, ITypeGenericService {
         readonly ITypeGenericRepository _typeGenericRepository;
        protected readonly NotificationHandler _notifications;

        readonly IMapper _mapper;

        public TypeGenericService(
            ITypeGenericRepository typeGenericRepository,
             NotificationHandler notifications,
             IMapper mapper
            ) : base(typeGenericRepository) {
            _typeGenericRepository = typeGenericRepository;
            _notifications = notifications;
             _mapper = mapper;
        }

        public async Task<TypeGeneric> Insert(TypeGeneric obj) {
            
            obj.Validate(obj, new TypeGenericValidator());
            _notifications.AddNotifications(obj.ValidationResult);
            
            if (!_notifications.HasNotifications) {
                await Post(obj);
            }

            return obj;
        }

        public async Task<TypeGeneric> Update(TypeGenericDto obj) {

            TypeGeneric typeGeneric = await _typeGenericRepository.GetById(obj.TypeGenericId);

            _mapper.Map(obj, typeGeneric);

            typeGeneric.Validate(typeGeneric, new TypeGenericValidator());
            _notifications.AddNotifications(typeGeneric.ValidationResult);

            if (!_notifications.HasNotifications) {
                await Put(typeGeneric);
            }

            return typeGeneric;
        }
    }
}
