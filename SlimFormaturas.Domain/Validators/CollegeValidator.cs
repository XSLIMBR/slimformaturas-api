using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using SlimFormaturas.Domain.Entities;

namespace SlimFormaturas.Domain.Validators {
    public class CollegeValidator : AbstractValidator<College> {
        public CollegeValidator() {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x => throw new ArgumentNullException("O objeto não foi encontrado!"));
            RuleFor(c => c.CorporateName)
                .NotEmpty()
                .NotNull()
                .Length(1, 50);
            RuleFor(c => c.FantasyName)
                .NotEmpty()
                .NotNull()
                .Length(1, 50);
            RuleFor(c => c.CNPJ)
                .NotEmpty()
                .NotNull()
                .Length(14);
            RuleFor(c => c.Bank)
                .NotEmpty()
                .NotNull()
                .Length(1, 50);
            RuleFor(c => c.Agency)
                .NotEmpty()
                .NotNull()
                .Length(1, 50);
            RuleFor(c => c.CheckingAccount)
                .NotEmpty()
                .NotNull()
                .Length(1, 50);
            RuleFor(c => c.Email)
                .NotEmpty()
                .NotNull()
                .Length(1, 50);
            RuleFor(c => c.Site)
                .NotEmpty()
                .NotNull()
                .Length(1, 50);
        }
    }
}
