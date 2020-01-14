using System;
using FluentValidation;
using SlimFormaturas.Domain.Entities;

namespace SlimFormaturas.Domain.Validators {
    public class ContractValidator : AbstractValidator<Contract>{
        public ContractValidator() {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x => throw new ArgumentNullException("O objeto não foi encontrado!"));
            RuleFor(c => c.Code)
                .NotEmpty()
                .NotNull()
                .Length(1, 50);
            RuleFor(c => c.Semester)
                .NotEmpty()
                .NotNull();
            RuleFor(c => c.Year)
                .NotEmpty()
                .NotNull();
        }
    }
}
