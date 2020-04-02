using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using System;
using System.Threading.Tasks;
using SlimFormaturas.Domain.Validators;

namespace SlimFormaturas.Service.Services
{
    public class UniversityService : BaseService<University>,IUniversityService
    {
        private readonly IUniversityRepository _universityRepository;
        protected readonly NotificationHandler _notifications;

        public UniversityService
            ( IUniversityRepository universityRepository, NotificationHandler notifications): base (universityRepository)
        {
            _universityRepository = universityRepository;
            _notifications = notifications;
        }

        public async Task<University> Insert(University obj)
        {
            University university = new University(obj.Name);
            if (university.Invalid)
            {
                _notifications.AddNotifications(university.ValidationResult);
            }

            if (!_notifications.HasNotifications) 
            {
                await Post(university);   
            }

            return obj;
        }

        public async Task<University> Update(University obj)
        {
            University university = await _universityRepository.GetById(obj.UniversityId);
            if (university != null)
            {
                university.Name = obj.Name;
                university.Validate(university, new  UniversityValidator());
                if (university.Valid)
                {
                    await Put(university);
                }
                else
                {
                    _notifications.AddNotifications(university.ValidationResult);
                }
            }
            else {
                _notifications.AddNotification("404", "Universidade", "Universidade com id = " + obj.UniversityId + "não foi encontrada");
            }
            return university;
        }
    }
}
