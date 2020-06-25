using System.Threading.Tasks;
using SlimFormaturas.Domain.Dto.Employee;
using SlimFormaturas.Domain.Entities;

namespace SlimFormaturas.Domain.Interfaces.Service {
    public interface IEmployeeService : IService<Employee> {
        Task<string> CreateUser(string cpf, string email);
        Task<Employee> Insert(Employee obj);
        Task<Employee> Update(EmployeeDto employeeDto);
        Task<Employee> GetAllById (string id);
    }
}
