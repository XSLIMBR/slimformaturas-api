using AutoMapper;
using SlimFormaturas.Domain.Dto.Course;
using SlimFormaturas.Domain.Dto.Course.Response;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using SlimFormaturas.Domain.Validators;
using System.Threading.Tasks;

namespace SlimFormaturas.Service.Services {
    public class CourseService : BaseService<Course>, ICourseService {
        private readonly ICourseRepository _courseRepository;
        protected readonly NotificationHandler _notifications;
        readonly IMapper _mapper;

        public CourseService(
             ICourseRepository courseRepository,
             NotificationHandler notifications,
              IMapper mapper
            ) : base(courseRepository) {
            _courseRepository = courseRepository;
            _notifications = notifications;
            _mapper = mapper;
        }

        public async Task<CourseResponse> Insert(CourseForCreationDto courseDto) {

            var course = _mapper.Map<Course>(courseDto);

            course.Validate(course, new CourseValidator());
            _notifications.AddNotifications(course.ValidationResult);

            if (!_notifications.HasNotifications) {
               await Post(course);
            }

            return _mapper.Map<CourseResponse>(course);
        }

        public async Task<CourseResponse> Update(CourseDto courseDto){

            Course course = await _courseRepository.GetById(courseDto.CourseId);

            if (course == null){
                _notifications.AddNotification("404", "CourseId", "Course with id = " + courseDto.CourseId + " not found");
                return null;
            }

            _mapper.Map(courseDto, course);

            course.Validate(course, new CourseValidator());
            _notifications.AddNotifications(course.ValidationResult);

            if (!_notifications.HasNotifications){
                await Put(course);
            }

            return _mapper.Map<CourseResponse>(course);
        }

        public async Task<Course> GetAllById(string id) {
            return await _courseRepository.GetAllById(id);
        }
    }
}
