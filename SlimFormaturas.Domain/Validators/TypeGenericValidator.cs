using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using SlimFormaturas.Domain.Entities;

namespace SlimFormaturas.Domain.Validators {
    public class TypeGenericValidator : AbstractValidator<TypeGeneric> {
        public TypeGenericValidator() {
            RuleFor(c => c)
                .NotNull();
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O nome nao pode ser em branco")
                .NotNull().WithMessage("É necessário informar o Nome.");
        }
    }
}
