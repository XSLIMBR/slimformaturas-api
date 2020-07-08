using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Infra.Data.Context;

namespace SlimFormaturas.Infra.Data.Repository {
    public class PermissionsRepository : BaseRepository<Permission>, IPermissionsRepository {
        public PermissionsRepository(MssqlContext context) : base(context) { }
    }
}
