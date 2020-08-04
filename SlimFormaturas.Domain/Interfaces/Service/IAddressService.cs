using System.Threading.Tasks;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Dto.Address;
using SlimFormaturas.Domain.Dto.Address.Response;

namespace SlimFormaturas.Domain.Interfaces.Service {
    public interface IAddressService : IService<Address> {
        Task<AddressResponse> Insert(Address obj);
        Task<AddressResponse> Update(AddressDto address);
    }
}
