using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using SlimFormaturas.Domain.Validators;
using System.Threading.Tasks;

namespace SlimFormaturas.Service.Services
{
    public class CourseService : BaseService<Course>, ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        protected readonly NotificationHandler _notifications;

        public CourseService
            (
             ICourseRepository courseRepository,
             NotificationHandler notifications
            ) : base(courseRepository)
        {
            _courseRepository = courseRepository;
            _notifications = notifications;
        }

        public async Task<Course> Insert(Course obj)
        {
            Course course = new Course(obj.Name);

            if (course.Invalid)
            {
                _notifications.AddNotifications(course.ValidationResult);
            }

             if (!_notifications.HasNotifications)
            {
                await Post(course);
            }
            return obj;
        }
    }
}
