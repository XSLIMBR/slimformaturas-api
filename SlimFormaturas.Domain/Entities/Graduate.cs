using System;
using System.Collections.Generic;
using System.Linq;

namespace SlimFormaturas.Domain.Entities {
    public class Graduate : Entity {

        public Graduate() {
            GraduateId = Guid.NewGuid().ToString();
        }

        public string GraduateId { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public string DadName { get; set; }
        public string MotherName { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        #region ContaBancária
        public string Bank { get; set; }
        public string Agency { get; set; }
        public string CheckingAccount { get; set; }
        #endregion

        public string UserId { get; private set; }

        public DateTime DateRegister { get; protected set; }

        public User User { get; private set; }
        public virtual IList<Address> Address { get; set; }
        public virtual IList<Phone> Phone { get; set; }
        public virtual IList<GraduateAlbum>  GraduateAlbum { get;set; }
        public virtual IList<GraduateCeremonial> GraduateCeremonial { get; set; }

        public void AddUser(string user) {
            UserId = user;
        }

        public string GetShortName() {
            var names = this.Name.Split(' ');
            return names.First() + " " + names.Last();
        }
    }
}
