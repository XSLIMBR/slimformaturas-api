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
            //Course course = new Course(obj.Name);

            Course course = null;

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

        public async Task<Course> Update(Course obj) 
        {
            Course course = await _courseRepository.GetById(obj.CourseId);
            if (course != null) 
            {
                course.Name = obj.Name;
               // course.GraduateCeremonial = obj.GraduateCeremonial;
               // course.ContractCourses = obj.ContractCourses;

                course.Validate(course, new CourseValidator());

                if (course.Valid)
                {
                    await Put(course);
                }
                else 
                {
                    _notifications.AddNotifications(course.ValidationResult);
                }
            }
            else 
                {
                    _notifications.AddNotification("404", "Curso", " Curso com id = " + obj.CourseId + "não foi encontrado");
                }
            return course;
        }
    }
}
