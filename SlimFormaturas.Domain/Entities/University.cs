using System;
using SlimFormaturas.Domain.Validators;
namespace SlimFormaturas.Domain.Entities
{
    public class University : Entity
    {
        public University() 
        {
             //Contrutor vazio
        }
        public University(string name) 
        {
            UniversityId = Guid.NewGuid().ToString();
            Name = name;
            Validate(this, new UniversityValidator());
        }
        public string UniversityId { get; set; }
        public string Name { get; set; }
    }
}
