using SlimFormaturas.Domain.Dto.Contract;
using SlimFormaturas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SlimFormaturas.Domain.Interfaces.Service
{
    public interface IContractService : IService<Contract>
    {
        Task<Contract> Insert(ContractForCreationDto contractForCreationDto);
        Task<Contract> Update(ContractDto contractDto);
        Task<Contract> GetAllById(string id);
        Task<IList<ContractSearchResponse>> Search(ContractSearch search);
    }
}
