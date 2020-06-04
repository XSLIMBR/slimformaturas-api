using SlimFormaturas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SlimFormaturas.Domain.Interfaces.Repository {
    public interface ISellerRepository : IRepository<Seller> {
        Task<Seller> GetAllById (string id);

    }
}
