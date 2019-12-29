using System;
using System.Collections.Generic;
using System.Text;

namespace SlimFormaturas.Domain.Entities
{
    public class Employee : Entity{
        public Employee() {
            EmployeeId = Guid.NewGuid().ToString();
        }

        public Employee(string employeeId, string name, string cpf, string rg,string sex, DateTime birthDate,string dadName,string motherName,string email, string photo,string bank,string agency,string checkingAccount) {
            EmployeeId = employeeId;
            Name = name;
            Cpf = cpf;
            Rg = rg;
            Sex = sex;
            BirthDate = birthDate;
            DadName = dadName;
            MotherName = motherName;
            Email = email;
            Photo = photo;
            Bank = bank;
            Agency = agency;
            CheckingAccount = checkingAccount;
            Address = new List<Address>();
            Phone = new List<Phone>();
        }
        public string EmployeeId { get;set; }
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
        public DateTime DateRegister { get; protected set; }

        public string UserId { get; private set; }

        public User User { get; private set; }
        public IList<Address> Address { get; set; }
        public IList<Phone> Phone { get; set; }

        public void AddUser(string user) {
            UserId = user;
        }
    }
}
