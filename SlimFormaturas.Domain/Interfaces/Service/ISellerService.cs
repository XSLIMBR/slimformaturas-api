using SlimFormaturas.Domain.Dto.Seller;
using SlimFormaturas.Domain.Entities;
using System.Threading.Tasks;

namespace SlimFormaturas.Domain.Interfaces.Service {
    public interface ISellerService : IService<Seller> {
        Task<string> CreateUser (string cpf, string email);
        Task<Seller> Insert (Seller obj);
        Task<Seller> Update (SellerDto sellerDto);
        Task<Seller> GetAllById (string id);
    }
}
