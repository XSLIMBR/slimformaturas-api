using System;
using System.Collections.Generic;
using SlimFormaturas.Domain.Validators;

namespace SlimFormaturas.Domain.Entities {
    public class College : Entity {
        public College() {
        }
        public College(string collegeId,string corporateName, string fantasyName, string cnpj,string bank, string agency, string checkingAccount, string email, string site) {
            CollegeId = Guid.NewGuid().ToString();
            CorporateName = corporateName;
            FantasyName = fantasyName;
            CNPJ = cnpj;
            Bank = bank;
            Agency = agency;
            CheckingAccount = checkingAccount;
            Email = email;
            Site = site;
            Address = new List<Address>();
            Phone = new List<Phone>();
            Validate(this, new CollegeValidator());
        }
        public string CollegeId { get; set; }
        public string CorporateName { get; set; }
        public string FantasyName { get; set; }
        public string CNPJ { get; set; }
        #region ContaBancária
        public string Bank { get; set; }
        public string Agency { get; set; }
        public string CheckingAccount { get; set; }
        #endregion
        public string Email { get; set; }
        public string Site { get; set; }
        public DateTime DateRegister { get; protected set; }

        public IList<Address> Address { get; set; }
        public IList<Phone> Phone { get; set; }
        public IList<Contract> Contract { get; set; }
    }
}
