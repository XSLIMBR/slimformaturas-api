using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;
using static SlimFormaturas.Domain.Entities.Permission;

namespace SlimFormaturas.Service.Services {
    public class PermissionsService : BaseService<Permission>, IPermissionsService {
        private readonly IPermissionsRepository _permissionsRepository;
        public PermissionsService(IPermissionsRepository permissionsRepository) : base(permissionsRepository) {
            _permissionsRepository = permissionsRepository;
        }

        public IList<Permission> GetPermissionsToDisplay() {

            var result = new List<Permission>();

            foreach (var permissionName in Enum.GetNames(typeof(Permissions))) {

                var member = (typeof(Permissions)).GetMember(permissionName);

                var displayAttribute = member[0].GetCustomAttribute<DisplayAttribute>();
                if (displayAttribute == null)
                    continue;

                //var permission = (Permissions)Enum.Parse((typeof(Permissions)), permissionName, false);

                result.Add(new Permission(displayAttribute.GroupName, displayAttribute.Name,
                        displayAttribute.Description));
            }

            return result;
        }
    }
}
