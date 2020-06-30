using SlimFormaturas.Domain.Entities;
using System.Threading.Tasks;

namespace SlimFormaturas.Domain.Interfaces.Repository
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<Course> GetAllById(string id);
    }
}
