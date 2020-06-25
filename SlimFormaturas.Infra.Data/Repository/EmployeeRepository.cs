using System.Threading.Tasks;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Infra.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using SlimFormaturas.Infra.CrossCutting.Identity.Models;

namespace SlimFormaturas.Infra.Data.Repository {
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository {
        private readonly UserManager<ApplicationUser> _userManager;
        public EmployeeRepository(MssqlContext context,
            UserManager<ApplicationUser> userManager) : base(context) {
            _userManager = userManager;
        }

        public async Task<Employee> GetAllById (string id) {

            var Employee = await Context.Employee
                .Include(c => c.Address)
                .Include(c => c.Phone)
                .FirstOrDefaultAsync(c => c.EmployeeId == id);

            return Employee;
        }

        public new async Task<IList<Employee>> GetAll () {
            var Employee = await Context.Employee
                .Include(c => c.Address)
                .Include(c => c.Phone)
                .ToListAsync();

            return Employee;
        }

        /*
        public async Task<int> RemoveAll(string id) {

            Context.Remove(GetAllById(id));

            var removeuser = await GetById(id);
            _ = await _userManager.DeleteAsync(_ = await _userManager.FindByIdAsync(removeuser.UserId));

            return await Context.SaveChangesAsync();
        }
        */
    }
}
