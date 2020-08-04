using System;
using FluentValidation;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Validators.Extensions;

namespace SlimFormaturas.Domain.Validators {
    public class CollegeValidator : AbstractValidator<College> {
        public CollegeValidator() {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x => throw new ArgumentNullException("O objeto não foi encontrado!"));
            RuleFor(c => c.CorporateName)
                .NotEmpty()
                .NotNull()
                .Length(1, 100);
            RuleFor(c => c.FantasyName)
                .NotEmpty()
                .NotNull()
                .Length(1, 100);
            RuleFor(c => c.CNPJ)
                .NotEmpty().WithMessage("É necessário informar o CNPJ.")
                .IsValidCNPJ().WithMessage("CNPJ Invalido!")
                .Length(14).WithMessage("O campo deve conter 14 caracteres")
                .NotNull();
        }
    }
}
