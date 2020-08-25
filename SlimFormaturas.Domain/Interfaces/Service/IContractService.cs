using SlimFormaturas.Domain.Dto.Contract;
using SlimFormaturas.Domain.Dto.Contract.Response;
using SlimFormaturas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SlimFormaturas.Domain.Interfaces.Service {
    public interface IContractService : IService<Contract> {
        Task<ContractResponse> Insert(ContractForCreationDto contractForCreationDto);
        Task<ContractResponse> Update(ContractDto contractDto);
        Task<Contract> GetAllById(string id);
        Task<IList<ContractSearchResponse>> Search(ContractSearch data);
        Task<IList<ContractSearchResponse>> GetByAnyKey(string key);
    }
}
