using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Infra.Data.Context;

namespace SlimFormaturas.Infra.Data.Repository {
    public class AddressRepository : BaseRepository<Address>, IAddressRepository {
        public AddressRepository(MssqlContext context) : base(context) {
        }
    }
}
