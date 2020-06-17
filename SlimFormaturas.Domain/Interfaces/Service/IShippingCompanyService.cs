using SlimFormaturas.Domain.Entities;
using System.Threading.Tasks;

namespace SlimFormaturas.Domain.Interfaces.Service {
    public interface IShippingCompanyService : IService<ShippingCompany>{
        Task<ShippingCompany> GetAllById (string id);
    }
}
