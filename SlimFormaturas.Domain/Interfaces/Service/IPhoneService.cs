using System.Threading.Tasks;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Dto.Phone;

namespace SlimFormaturas.Domain.Interfaces.Service {
    public interface IPhoneService : IService<Phone> {
        Task<Phone> Insert(Phone obj);
        Task<Phone> Update(PhoneDto phone);
    }
}
