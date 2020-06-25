using System;
using System.Threading.Tasks;
using SlimFormaturas.Domain.Entities;

namespace SlimFormaturas.Domain.Interfaces.Repository {
    public interface IEmployeeRepository : IRepository<Employee> {
        Task<Employee> GetAllById (string id);
    }
}
