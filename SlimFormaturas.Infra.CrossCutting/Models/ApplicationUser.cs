using Microsoft.AspNetCore.Identity;
using SlimFormaturas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlimFormaturas.Infra.CrossCutting.Identity.Models {
    public class ApplicationUser : IdentityUser {
        public virtual user_type User_Type { get; set; }
    }
}
