using System;
using System.Collections.Generic;
using System.Text;

namespace SlimFormaturas.Infra.CrossCutting.Identity.Models {
    public class Register {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
