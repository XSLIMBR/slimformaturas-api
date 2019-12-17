using System;
using SlimFormaturas.Domain.Validators;

namespace SlimFormaturas.Domain.Entities {
    public class Address : Entity {
        public Address() {
            AddressId = Guid.NewGuid().ToString();
        }

        public Address(string addressId, string cep, string street, string number, string complement, string neighborhood, string city, string uf, TypeGeneric typeGeneric) {
            AddressId = addressId;
            Cep = cep;
            Street = street;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            City = city;
            Uf = uf;
            TypeGeneric = typeGeneric;
            Validate(this, new AddressValidator());
        }

        public string AddressId { get; private set; }
        public string Cep { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string Uf { get; set; }

        public string TypeGenericId { get; set; }
        public string GraduateId { get; set; }


        public TypeGeneric TypeGeneric { get; set; }
        public Graduate Graduate { get; set; }

    }
}
