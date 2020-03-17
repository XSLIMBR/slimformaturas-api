using SlimFormaturas.Domain.Entities;
using System.Threading.Tasks;

namespace SlimFormaturas.Domain.Interfaces.Service
{
    public interface ICourseService : IService<Course>
    {
        Task<Course> Insert(Course obj);

        Task<Course> Update(Course obj);
    }
}

