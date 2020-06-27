using AutoMapper;
using SlimFormaturas.Domain.Dto.College;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using SlimFormaturas.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SlimFormaturas.Service.Services {
    public class CollegeService : BaseService<College>, ICollegeService {
        private readonly ICollegeRepository _CollegeRepository;
        protected readonly NotificationHandler _notifications;
        protected readonly ITypeGenericRepository _typeGenericRepository;
        readonly IMapper _mapper;

        public CollegeService (
            ICollegeRepository CollegeRepository,
            NotificationHandler notifications,
             IMapper mapper,
            ITypeGenericRepository typeGenericRepository) : base(CollegeRepository) {
            _CollegeRepository = CollegeRepository;
            _notifications = notifications;
            _typeGenericRepository = typeGenericRepository;
            _mapper = mapper;
        }

        public async Task<College> Insert (College obj) {

            obj.Validate(obj, new CollegeValidator());
            _notifications.AddNotifications(obj.ValidationResult);

            foreach (var item in obj.Address) {
                item.Validate(item, new AddressValidator());
                _notifications.AddNotifications(item.ValidationResult);
            }

            foreach (var item in obj.Phone) {
                item.Validate(item, new PhoneValidator());
                _notifications.AddNotifications(item.ValidationResult);
            }

            if (!_notifications.HasNotifications) {
                await Post(obj);
            }

            return obj;
        }

        public async Task<College> Update (CollegeDto CollegeDto) {

            College College = await _CollegeRepository.GetAllById(CollegeDto.CollegeId);

            _mapper.Map(CollegeDto, College);

            College.Validate(College, new CollegeValidator());
            _notifications.AddNotifications(College.ValidationResult);

            foreach (var item in College.Address) {
                item.Validate(item, new AddressValidator());
                _notifications.AddNotifications(item.ValidationResult);
            }

            foreach (var item in College.Phone) {
                item.Validate(item, new PhoneValidator());
                _notifications.AddNotifications(item.ValidationResult);
            }

            if (!_notifications.HasNotifications) {
                await Put(College);
            }

            return College;
        }

        public async Task<College> GetAllById (string id) {
            return await _CollegeRepository.GetAllById(id);
        }
    }
}
