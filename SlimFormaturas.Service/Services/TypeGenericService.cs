using System;
using System.Collections.Generic;
using System.Text;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;

namespace SlimFormaturas.Service.Services {
    public class TypeGenericService : BaseService<TypeGeneric>, ITypeGenericService {
        private readonly ITypeGenericRepository _typeGenericRepository;

        public TypeGenericService(
            ITypeGenericRepository typeGenericRepository,
             NotificationHandler notifications) : base(typeGenericRepository, notifications) {
            _typeGenericRepository = typeGenericRepository;
        }

        //pesistencia expecifica aqui
    }
}
