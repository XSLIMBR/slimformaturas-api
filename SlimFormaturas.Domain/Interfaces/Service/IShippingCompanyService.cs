using SlimFormaturas.Domain.Dto.ShippingCompany;
using SlimFormaturas.Domain.Dto.ShippingCompany.Response;
using SlimFormaturas.Domain.Entities;
using System.Threading.Tasks;

namespace SlimFormaturas.Domain.Interfaces.Service {
    public interface IShippingCompanyService : IService<ShippingCompany>{
        Task<ShippingCompany> GetAllById (string id);
        Task<ShippingCompanyResponse> Insert (ShippingCompany obj);
        Task<ShippingCompanyResponse> Update (ShippingCompanyDto graduateDto);
    }
}
