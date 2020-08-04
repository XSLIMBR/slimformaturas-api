using AutoMapper;
using SlimFormaturas.Domain.Dto.College;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using SlimFormaturas.Domain.Validators;
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

        public async Task<College> Insert (CollegeForCreationDto collegeForCreationDto) {

            var college = _mapper.Map<College>(collegeForCreationDto);

            college.Validate(college, new CollegeValidator());
            _notifications.AddNotifications(college.ValidationResult);

            foreach (var item in college.Address) {
                item.Validate(item, new AddressValidator());
                _notifications.AddNotifications(item.ValidationResult);
            }

            foreach (var item in college.Phone) {
                item.Validate(item, new PhoneValidator());
                _notifications.AddNotifications(item.ValidationResult);
            }

            if (!_notifications.HasNotifications) {
                return await Post(college);
            }

            return null;
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
                return await Put(College);
            }

            return null;
        }

        public async Task<College> GetAllById (string id) {
            return await _CollegeRepository.GetAllById(id);
        }
    }
}
