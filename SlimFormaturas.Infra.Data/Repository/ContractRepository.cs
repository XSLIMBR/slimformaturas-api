using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Infra.Data.Context;

namespace SlimFormaturas.Infra.Data.Repository
{
    public class ContractRepository : BaseRepository<Contract>, IContractRepository
    {
        public ContractRepository(MssqlContext context) : base(context)
        {
        }
    }
}
