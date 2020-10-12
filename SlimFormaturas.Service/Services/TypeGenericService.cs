using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SlimFormaturas.Domain.Dto.TypeGeneric;
using SlimFormaturas.Domain.Dto.TypeGeneric.Response;
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

        public async Task<TypeGenericResponse> Insert(TypeGenericForCreationDto obj) {

            var typeGeneric = _mapper.Map<TypeGeneric>(obj);

            var typeGenericSearch = await _typeGenericRepository.FirstOrDefault(a => a.Name.Contains(obj.Name) && a.Localization == typeGeneric.Localization);

            if (typeGenericSearch != null) {
                _notifications.AddNotification("409", "Nome", "Esse Nome já está cadastrado!");
            }

            typeGeneric.Validate(typeGeneric, new TypeGenericValidator());
            _notifications.AddNotifications(typeGeneric.ValidationResult);

            if (!_notifications.HasNotifications) {
                await Post(typeGeneric);
            }

            return _mapper.Map<TypeGenericResponse>(typeGeneric);
        }

        public async Task<TypeGenericResponse> Update(TypeGenericDto obj) {

            TypeGeneric typeGeneric = await _typeGenericRepository.GetById(obj.TypeGenericId);

            var typeGenericSearch = await _typeGenericRepository.FirstOrDefault(a => a.Name.Contains(obj.Name) && a.Localization == typeGeneric.Localization && a.TypeGenericId != typeGeneric.TypeGenericId);

            if (typeGenericSearch != null) {
                _notifications.AddNotification("409", "Nome", "Esse Nome já está cadastrado!");
            }

            _mapper.Map(obj, typeGeneric);

            typeGeneric.Validate(typeGeneric, new TypeGenericValidator());
            _notifications.AddNotifications(typeGeneric.ValidationResult);

            if (!_notifications.HasNotifications) {
                await Put(typeGeneric);
            }

            return _mapper.Map<TypeGenericResponse>(typeGeneric);
        }

    }
}
