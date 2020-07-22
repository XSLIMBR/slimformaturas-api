using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace SlimFormaturas.Domain.Entities {
    public class Permission {

        private string groupName;
        private string name;
        private string description;
        //public Permissions permission;

        public Permission(string groupName, string name, string description) {
            this.groupName = groupName;
            this.name = name;
            this.description = description;
            //this.permission = permission;
        }

        public enum Permissions {
            [Display(GroupName = "Graduate", Name = "Incluir", Description = "Incluir novo formando")]
            GraduateIncluir = 0x10,
            [Display(GroupName = "Graduate", Name = "Editar", Description = "Editar formando")]
            GraduatEditar = 0x11
        }

    }
}
