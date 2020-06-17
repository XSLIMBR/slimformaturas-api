using Microsoft.EntityFrameworkCore;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Infra.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SlimFormaturas.Infra.Data.Repository {
    public class ShippingCompanyRepository : BaseRepository<ShippingCompany>, IShippingCompanyRepository {
        public ShippingCompanyRepository (MssqlContext context) : base(context) { }
        public async Task<ShippingCompany> GetAllById (string id) {

            var shippingCompany = await Context.ShippingCompany
                .Include(c => c.Address)
                .Include(c => c.Phone)
                .FirstOrDefaultAsync(c => c.ShippingCompanyId == id);

            return shippingCompany;
        }

        public new async Task<IList<ShippingCompany>> GetAll () {
            var shippingCompany = await Context.ShippingCompany
                .Include(c => c.Address)
                .Include(c => c.Phone)
                .ToListAsync();

            return shippingCompany;
        }
    }
}
