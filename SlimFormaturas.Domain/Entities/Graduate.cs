using System;
using System.Collections.Generic;
using SlimFormaturas.Domain.Validators;

namespace SlimFormaturas.Domain.Entities {
    public class Graduate : Entity{

        //Limpo para o entityframework
        public Graduate() {
            GraduateId = Guid.NewGuid().ToString();
        }

        public Graduate(string graduateId, string name, string cpf, string rg, bool sex, DateTime birthDate, string dadName, string motherName, bool committee, string email, string photo, string bank, string agency, string checkingAccount) {
            GraduateId = graduateId;
            Name = name;
            Cpf = cpf;
            Rg = rg;
            Sex = sex;
            BirthDate = birthDate;
            DadName = dadName;
            MotherName = motherName;
            Committee = committee;
            Email = email;
            Photo = photo;
            Bank = bank;
            Agency = agency;
            CheckingAccount = checkingAccount;
            Address = new List<Address>();
            Phone = new List<Phone>();
            Validate(this, new GraduateValidator());
        }

        public string GraduateId { get; private set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public bool Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public string DadName { get; set; }
        public string MotherName { get; set; }
        public bool Committee { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        #region ContaBancária
        public string Bank { get; set; }
        public string Agency { get; set; }
        public string CheckingAccount { get; set; }
        #endregion

        public string UserId { get; private set; }

        public DateTime DateRegister { get; protected set; }

        public User User { get; protected set;}
        public IList<Address> Address { get; set; }
        public IList<Phone> Phone { get; set; } 

        public void AddUser(string userId) {
            UserId = userId;
        }

        public void AddAddress(IList<Address> addresses) {
            foreach (var address in addresses) {
                Address.Add(new Address(address.AddressId,address.Cep,address.Street,address.Number,address.Complement,address.Neighborhood,address.City,address.Uf,address.TypeGeneric.TypeGenericId,this.GraduateId));
            }
        }
        public void AddPhone(IList<Phone> phones) {
            foreach (var phone in phones) {
                Phone.Add(new Phone(phone.PhoneId,phone.Ddd,phone.PhoneNumber,this.GraduateId));
            }
        }
    }
}
