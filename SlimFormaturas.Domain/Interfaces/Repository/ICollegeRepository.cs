using System;
using System.Threading.Tasks;
using SlimFormaturas.Domain.Entities;

namespace SlimFormaturas.Domain.Interfaces.Repository {
    public interface ICollegeRepository : IRepository<College> {
        Task<College> GetAllById (string id);
    }
}
