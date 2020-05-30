using System;
using System.Threading.Tasks;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using SlimFormaturas.Domain.Validators;
using SlimFormaturas.Infra.Data.Repository;

namespace SlimFormaturas.Service.Services
{
    public class PhoneService : BaseService<Phone>, IPhoneService
    {
        protected readonly IPhoneRepository _phoneRepository;
        protected readonly NotificationHandler _notifications;
        protected readonly ITypeGenericRepository _typeGenericRepository;
        protected readonly IGraduateRepository _graduateRepository;

        public PhoneService(
            IGraduateRepository graduateRepository,
            IPhoneRepository phoneRepository,
            NotificationHandler notifications,
            ITypeGenericRepository typeGenericRepository) : base(phoneRepository) {
            _phoneRepository = phoneRepository;
            _notifications = notifications;
            _typeGenericRepository = typeGenericRepository;
            _graduateRepository = graduateRepository;
        }

        public async Task<Phone> Insert(Phone obj) {
            //Phone phone = new Phone(obj.Ddd, obj.PhoneNumber, await _typeGenericRepository.GetById(obj.TypeGenericId));

            Phone phone = null;

            if (obj.GraduateId != null) {
                phone.Graduate = await _graduateRepository.GetById(obj.GraduateId);
            }

            if (phone.Invalid) {
                _notifications.AddNotifications(phone.ValidationResult);
            }

            if (!_notifications.HasNotifications) {
                await Post(phone);
            }

            return obj;
        }

        public async Task<Phone> Update(Phone obj) {

            Phone phone = await _phoneRepository.GetById(obj.PhoneId);

            if (phone != null) {

                phone.Ddd = obj.Ddd;
                phone.PhoneNumber = obj.PhoneNumber;
                phone.TypeGeneric = await _typeGenericRepository.GetById(obj.TypeGenericId);

                phone.Validate(phone, new PhoneValidator());

                if (phone.Valid) {
                    await Put(phone);
                } else {
                    _notifications.AddNotifications(phone.ValidationResult);
                }
            } else {
                _notifications.AddNotification("404", "PhoneId", "Graduate with id = " + obj.PhoneId + " not found");
            }

            return phone;
        }
    }
}
