using SlimFormaturas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SlimFormaturas.Domain.Interfaces.Service
{
    public interface IContractService : IService<Contract>
    {
        Task<Contract> Insert(Contract obj);
    }
}
