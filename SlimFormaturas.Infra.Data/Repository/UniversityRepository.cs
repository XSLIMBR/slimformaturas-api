using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Infra.Data.Context;

namespace SlimFormaturas.Infra.Data.Repository
{
    public class UniversityRepository : BaseRepository<University>, IUniversityRepository
    {
        public UniversityRepository(MssqlContext context) : base (context)
        {  
        }
    }
}
