using FluentValidation;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Validators.Extensions;
using System;

namespace SlimFormaturas.Domain.Validators {
    public class PhoneValidator : AbstractValidator<Phone>{
        public PhoneValidator() {
            RuleFor(c => c)
                 .NotNull()
                .OnAnyFailure(x => throw new ArgumentNullException("O objeto não foi encontrado!"));
            RuleFor(c => c.Ddd)
                .NotEmpty().WithMessage("É necessário informar o DDD.")
                .NotNull()
                .Length(3).WithMessage("O campo nome deve ter 3 caracteres");
            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("É necessário informar o numero de telefone.")
                .NotNull()
                .Length(8,9).WithMessage("O campo nome deve ter no meximo 9 caracteres");
            RuleFor(c => c.TypeGenericId)
                .NotEmpty().WithMessage("É necessário informar a Tipo.")
                .NotNull();
        }
    }
}
