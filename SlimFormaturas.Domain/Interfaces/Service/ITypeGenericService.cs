using SlimFormaturas.Domain.Dto.TypeGeneric;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using System.Threading.Tasks;

namespace SlimFormaturas.Domain.Interfaces.Service {
    public interface ITypeGenericService : IService<TypeGeneric> {
        Task<TypeGeneric> Insert(TypeGeneric obj);
        Task<TypeGeneric> Update(TypeGenericDto obj);
    }
}
