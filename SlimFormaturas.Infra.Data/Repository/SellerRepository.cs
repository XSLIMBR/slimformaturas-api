using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Infra.CrossCutting.Identity.Models;
using SlimFormaturas.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SlimFormaturas.Infra.Data.Repository {
    public class SellerRepository : BaseRepository<Seller>, ISellerRepository {
        private readonly UserManager<ApplicationUser> _userManager;
        public SellerRepository (MssqlContext context,
            UserManager<ApplicationUser> userManager) : base(context) {
            _userManager = userManager;
        }

        public async Task<Seller> GetAllById (string id) {

            var seller = await Context.Seller
                .Include(c => c.Address)
                .Include(c => c.Phone)
                .FirstOrDefaultAsync(c => c.SellerId == id);

            return seller;
        }

        public new async Task<IList<Seller>> GetAll () {
            var seller = await Context.Seller
                .Include(c => c.Address)
                .Include(c => c.Phone)
                .ToListAsync();

            return seller;
        }

        public new async Task<int> Remove (string id) {

            var removeuser = await GetById(id);

            _ = await _userManager.DeleteAsync(_ = await _userManager.FindByIdAsync(removeuser.UserId));

            return await Context.SaveChangesAsync();
        }
    }
}
