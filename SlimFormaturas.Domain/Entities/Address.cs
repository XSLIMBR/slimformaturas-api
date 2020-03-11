using System;
using SlimFormaturas.Domain.Validators;

namespace SlimFormaturas.Domain.Entities {
    public class Address : Entity {
        public Address() {
        }

        public Address(string cep, string street, string number, string complement, string neighborhood, string city, string uf, TypeGeneric typeGeneric) {
            AddressId = Guid.NewGuid().ToString();
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
        public string CollegeId { get; set; }
        public string EmployeeId { get; set; }
        public string SellerId { get; set; }
        public string ShippingCompanyId { get; set; }


        public TypeGeneric TypeGeneric { get; set; }
        public Graduate Graduate { get; set; }
        public College College { get; set; }
        public Employee Employee { get; set; }
        public Seller Seller { get; set; }
        public ShippingCompany ShippingCompany { get; set; }

    }
}
