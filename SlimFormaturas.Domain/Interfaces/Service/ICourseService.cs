using SlimFormaturas.Domain.Dto.Course;
using SlimFormaturas.Domain.Entities;
using System.Threading.Tasks;

namespace SlimFormaturas.Domain.Interfaces.Service
{
    public interface ICourseService : IService<Course>
    {
        Task<Course> Insert(CourseForCreationDto obj);
        Task<Course> Update(CourseDto courseDto);
        Task<Course> GetAllById(string id);
    }
}

