using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Infra.Data.Context;

namespace SlimFormaturas.Infra.Data.Repository {
    public class PhoneRepository : BaseRepository<Phone>, IPhoneRepository {
        public PhoneRepository(MssqlContext context) : base(context) {
        }
    }
}
