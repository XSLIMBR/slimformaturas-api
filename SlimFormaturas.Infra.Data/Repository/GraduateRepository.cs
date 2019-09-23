using System;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Infra.Data.Context;

namespace SlimFormaturas.Infra.Data.Repository {
    public class GraduateRepository : BaseRepository<Graduate>, IGraduateRepository {
        public GraduateRepository(MssqlContext context) : base(context) { }

    }
}
