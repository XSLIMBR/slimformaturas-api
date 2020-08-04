using SlimFormaturas.Domain.Dto.Seller;
using SlimFormaturas.Domain.Dto.Seller.Response;
using SlimFormaturas.Domain.Entities;
using System.Threading.Tasks;

namespace SlimFormaturas.Domain.Interfaces.Service {
    public interface ISellerService : IService<Seller> {
        Task<string> CreateUser (string cpf, string email);
        Task<SellerResponse> Insert (Seller obj);
        Task<SellerResponse> Update (SellerDto sellerDto);
        Task<Seller> GetAllById (string id);
    }
}
