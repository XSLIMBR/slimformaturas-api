using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SlimFormaturas.Domain.Entities {
    public class Address {
        public Address() {
            AddressId = Guid.NewGuid().ToString();
        }
        public string AddressId { get; set; }
        public string Cep { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string Uf { get; set; }
        public bool Active { get; set; }

        public virtual Graduate Graduate { get; set; }
    }
}
