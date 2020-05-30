using System;
using System.Collections.Generic;
using System.Text;

namespace SlimFormaturas.Domain.Entities {
    public class Seller : Entity {
        public Seller() {
            SellerId = Guid.NewGuid().ToString();
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
