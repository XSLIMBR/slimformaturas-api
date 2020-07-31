using System.Threading.Tasks;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Infra.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using SlimFormaturas.Infra.CrossCutting.Identity.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace SlimFormaturas.Infra.Data.Repository {
    public class GraduateRepository : BaseRepository<Graduate>, IGraduateRepository {
        private readonly UserManager<ApplicationUser> _userManager;
        public GraduateRepository(MssqlContext context,
            UserManager<ApplicationUser> userManager) : base(context) {
            _userManager = userManager;
        }

        public async Task<Graduate> GetAllById (string id) {

            var graduate = await Context.Graduate
                .Include(c => c.Address)
                .Include(c => c.Phone)
                .FirstOrDefaultAsync(c => c.GraduateId == id);

            return graduate;
        }

        public new async Task<IList<Graduate>> GetAll () {
            var graduate = await Context.Graduate
                .Include(c => c.Address)
                .Include(c => c.Phone)
                .ToListAsync();

            return graduate;
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
