using System;
using System.Collections.Generic;
using System.Text;

namespace SlimFormaturas.Domain.Entities {
    public class ShippingCompany : Entity {
        public ShippingCompany() {
            ShippingCompanyId = Guid.NewGuid().ToString();
        }

        public ShippingCompany(string shippingCompanyId, string name,string email,string site,string bank,string agency,string checkingAccount) {
            ShippingCompanyId = shippingCompanyId;
            Name = name;
            Email = email;
            Site = site;
            Bank = bank;
            Agency = agency;
            CheckingAccount = checkingAccount;
            Address = new List<Address>();
            Phone = new List<Phone>();
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
