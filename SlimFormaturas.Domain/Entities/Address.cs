using System;
using SlimFormaturas.Domain.Validators;

namespace SlimFormaturas.Domain.Entities {
    public class Address : Entity {

        public Address() {
            AddressId = Guid.NewGuid().ToString();
        }

        public string AddressId { get; private set; }
        public bool Default { get; set; }
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


        public virtual TypeGeneric TypeGeneric { get; set; }
        public virtual Graduate Graduate { get; set; }
        public virtual College College { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Seller Seller { get; set; }
        public virtual ShippingCompany ShippingCompany { get; set; }

    }
}
