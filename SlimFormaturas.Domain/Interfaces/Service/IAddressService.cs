using System.Threading.Tasks;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Dto.Address;

namespace SlimFormaturas.Domain.Interfaces.Service {
    public interface IAddressService : IService<Address> {
        Task<Address> Insert(Address obj);
        Task<Address> Update(AddressDto address);
    }
}
