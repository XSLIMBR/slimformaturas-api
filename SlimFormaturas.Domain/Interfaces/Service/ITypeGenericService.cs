using SlimFormaturas.Domain.Dto.TypeGeneric;
using SlimFormaturas.Domain.Dto.TypeGeneric.Response;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using System.Threading.Tasks;

namespace SlimFormaturas.Domain.Interfaces.Service {
    public interface ITypeGenericService : IService<TypeGeneric> {
        Task<TypeGenericResponse> Insert(TypeGeneric obj);
        Task<TypeGenericResponse> Update(TypeGenericDto obj);
    }
}
