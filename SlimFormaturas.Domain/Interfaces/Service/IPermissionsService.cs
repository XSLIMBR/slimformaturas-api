using SlimFormaturas.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;

namespace SlimFormaturas.Domain.Entities {
    public interface IPermissionsService : IService<Permission> {
        IList<Permission> GetPermissionsToDisplay();
    }
}
