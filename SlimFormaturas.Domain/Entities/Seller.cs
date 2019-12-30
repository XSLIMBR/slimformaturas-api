using System;
using System.Collections.Generic;
using System.Text;

namespace SlimFormaturas.Domain.Entities {
    public class Seller : Entity {
        public Seller() {
            SellerId = Guid.NewGuid().ToString();
        }

        public Seller(string sellerId, string name, string cpf, string rg,string sex, DateTime birthDate,string email, string photo,string bank,string agency,string checkingAccount) {
            SellerId = sellerId;
            Name = name;
            Cpf = cpf;
            Rg = rg;
            Sex = sex;
            BirthDate = birthDate;
            Email = email;
            Photo = photo;
            Bank = bank;
            Agency = agency;
            CheckingAccount = checkingAccount;
            Address = new List<Address>();
            Phone = new List<Phone>();
        }
        public string SellerId { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        #region ContaBancária
        public string Bank { get; set; }
        public string Agency { get; set; }
        public string CheckingAccount { get; set; }
        #endregion

        public string UserId { get; private set; }

        public User User { get; private set; }
        public IList<Address> Address { get; set; }
        public IList<Phone> Phone { get; set; }

        public void AddUser(string user) {
            UserId = user;
        }
    }
}
