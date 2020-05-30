using System;
using System.Collections.Generic;
using System.Text;

namespace SlimFormaturas.Domain.Entities {
    public class ShippingCompany : Entity {
        public ShippingCompany() {
            ShippingCompanyId = Guid.NewGuid().ToString();
        }

        public string ShippingCompanyId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        #region Dados Bancarios
        public string Bank { get; set; }
        public string Agency { get; set; }
        public string CheckingAccount { get; set; }
        #endregion
        public DateTime DateRegister { get; set; }
        public IList<Address> Address { get; set; }
        public IList<Phone> Phone { get; set; }
    }
}
