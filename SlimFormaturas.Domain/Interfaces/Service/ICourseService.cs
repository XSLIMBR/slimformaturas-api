using SlimFormaturas.Domain.Dto.Course;
using SlimFormaturas.Domain.Dto.Course.Response;
using SlimFormaturas.Domain.Entities;
using System.Threading.Tasks;

namespace SlimFormaturas.Domain.Interfaces.Service
{
    public interface ICourseService : IService<Course>
    {
        Task<CourseResponse> Insert(CourseForCreationDto obj);
        Task<CourseResponse> Update(CourseDto courseDto);
        Task<Course> GetAllById(string id);
    }
}

