using SlimFormaturas.Domain.Dto.ShippingCompany;
using SlimFormaturas.Domain.Entities;
using System.Threading.Tasks;

namespace SlimFormaturas.Domain.Interfaces.Service {
    public interface IShippingCompanyService : IService<ShippingCompany>{
        Task<ShippingCompany> GetAllById (string id);
        Task<ShippingCompany> Insert (ShippingCompany obj);
        Task<ShippingCompany> Update (ShippingCompanyDto graduateDto);
    }
}
