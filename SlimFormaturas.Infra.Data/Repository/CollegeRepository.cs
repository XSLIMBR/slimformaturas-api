using Microsoft.EntityFrameworkCore;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Infra.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SlimFormaturas.Infra.Data.Repository {
    public class CollegeRepository : BaseRepository<College>, ICollegeRepository {
        public CollegeRepository (MssqlContext context) : base(context) { }
        
        public async Task<College> GetAllById (string id) {

            var College = await Context.College
                .Include(c => c.Address)
                .Include(c => c.Phone)
                .Include(c => c.Contract)
                .FirstOrDefaultAsync(c => c.CollegeId == id);

            return College;
        }

        public new async Task<IList<College>> GetAll () {
            var College = await Context.College
                .ToListAsync();

            return College;
        }
    }
}
