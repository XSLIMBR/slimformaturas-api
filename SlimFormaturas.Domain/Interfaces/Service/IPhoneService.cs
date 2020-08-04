using System.Threading.Tasks;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Dto.Phone;
using SlimFormaturas.Domain.Dto.Phone.Response;

namespace SlimFormaturas.Domain.Interfaces.Service {
    public interface IPhoneService : IService<Phone> {
        Task<PhoneResponse> Insert(Phone obj);
        Task<PhoneResponse> Update(PhoneDto phone);
    }
}
