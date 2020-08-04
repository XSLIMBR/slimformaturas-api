using System;
using System.Threading.Tasks;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using SlimFormaturas.Domain.Validators;
using SlimFormaturas.Infra.Data.Repository;
using AutoMapper;
using SlimFormaturas.Domain.Dto.Phone;
using SlimFormaturas.Domain.Dto.Phone.Response;

namespace SlimFormaturas.Service.Services
{
    public class PhoneService : BaseService<Phone>, IPhoneService
    {
        protected readonly IPhoneRepository _phoneRepository;
        protected readonly NotificationHandler _notifications;
        protected readonly ITypeGenericRepository _typeGenericRepository;
        protected readonly IGraduateRepository _graduateRepository;
        readonly IMapper _mapper;

        public PhoneService(
            IGraduateRepository graduateRepository,
            IPhoneRepository phoneRepository,
            NotificationHandler notifications,
            IMapper mapper,
            ITypeGenericRepository typeGenericRepository) : base(phoneRepository) {
            _phoneRepository = phoneRepository;
            _notifications = notifications;
            _typeGenericRepository = typeGenericRepository;
            _mapper = mapper;
            _graduateRepository = graduateRepository;
        }

        public async Task<PhoneResponse> Insert(Phone phone) {
            //Phone phone = new Phone(obj.Ddd, obj.PhoneNumber, await _typeGenericRepository.GetById(obj.TypeGenericId));

            phone.Validate(phone, new PhoneValidator());
            _notifications.AddNotifications(phone.ValidationResult);

            if (phone.GraduateId != null) {
                phone.Graduate = await _graduateRepository.GetById(phone.GraduateId);
            }

            if (phone.Invalid) {
                _notifications.AddNotifications(phone.ValidationResult);
            }

            if (!_notifications.HasNotifications) {
                await Post(phone);
            }

            return _mapper.Map<PhoneResponse>(phone);
        }

        public async Task<PhoneResponse> Update(PhoneDto phoneDto) {

            Phone phone = await _phoneRepository.GetById(phoneDto.PhoneId);

            if (phone != null) {

                _mapper.Map(phoneDto, phone);

                phone.Validate(phone, new PhoneValidator());
                _notifications.AddNotifications(phone.ValidationResult);

                if (!_notifications.HasNotifications) {
                    await Put(phone);
                }

            } else {
                _notifications.AddNotification("404", "PhoneId", "Phone with id = " + phoneDto.PhoneId + " not found");
            }

            return _mapper.Map<PhoneResponse>(phone);
        }
    }
}
