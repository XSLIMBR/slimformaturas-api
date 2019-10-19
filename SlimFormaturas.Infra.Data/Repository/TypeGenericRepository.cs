using System;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using SlimFormaturas.Infra.Data.Context;

namespace SlimFormaturas.Infra.Data.Repository {
    public class TypeGenericRepository : BaseRepository<TypeGeneric>, ITypeGenericRepository {
        public TypeGenericRepository(MssqlContext context) : base(context) { }

    }
}
