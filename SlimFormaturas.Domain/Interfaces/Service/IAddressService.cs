using System.Threading.Tasks;
using SlimFormaturas.Domain.Entities;

namespace SlimFormaturas.Domain.Interfaces.Service {
    public interface IAddressService : IService<Address> {
        Task<Address> Insert(Address obj);
        Task<Address> Update(Address address);
    }
}
