using System;
using SlimFormaturas.Domain.Validators;
namespace SlimFormaturas.Domain.Entities
{
    public class University : Entity
    {
        public University() {
            UniversityId = Guid.NewGuid().ToString();
        }

        public string UniversityId { get; set; }
        public string Name { get; set; }
    }
}
