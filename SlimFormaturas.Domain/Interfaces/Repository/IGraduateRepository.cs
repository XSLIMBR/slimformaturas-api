using System;
using System.Threading.Tasks;
using SlimFormaturas.Domain.Entities;

namespace SlimFormaturas.Domain.Interfaces.Repository {
    public interface IGraduateRepository : IRepository<Graduate> {
        Task<Graduate> GetAllById (string id);
    }
}
