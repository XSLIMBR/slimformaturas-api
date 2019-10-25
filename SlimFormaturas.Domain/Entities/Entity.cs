using FluentValidation;
using FluentValidation.Results;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SlimFormaturas.Domain.Entities {
    public abstract class Entity {
        [NotMapped]
        public Guid Id { get; protected set; }
        [NotMapped]
        public bool Valid { get;  set; }
        [NotMapped]
        public bool Invalid => !Valid;
        [NotMapped]
        public ValidationResult ValidationResult { get;  set; }

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator) {
            ValidationResult = validator.Validate(model);
            return Valid = ValidationResult.IsValid;
        }
    }
}
