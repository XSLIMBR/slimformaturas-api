using System;

namespace SlimFormaturas.Domain.Entities {
    public class User {
        public User(){
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; private set; }
        public virtual string Email { get; private set; }
        public virtual bool EmailConfirmed { get; private set; }
        public virtual string PasswordHash { get; private set; }
        public virtual string SecurityStamp { get; private set; }
        public virtual string PhoneNumber { get; private set; }
        public virtual bool PhoneNumberConfirmed { get; private set; }
        public virtual bool TwoFactorEnabled { get; private set; }
        public virtual DateTime? LockoutEnd { get; private set; }
        public virtual bool LockoutEnabled { get; private set; }
        public virtual int AccessFailedCount { get; private set; }
        public virtual string UserName { get; private set; }
        public virtual user_type User_Type { get; set; }
    }
    public enum user_type { 
        Formando,
        Colaborador,
        Vendedor
    }
}
