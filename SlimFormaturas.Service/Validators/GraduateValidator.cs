using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Service.Validators.Extensions;

namespace SlimFormaturas.Service.Validators {
    public class GraduateValidator : AbstractValidator<Graduate> {
        public GraduateValidator() {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x => throw new ArgumentNullException("O objeto não foi encontrado!"));
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("É necessário informar o Nome.")
                .NotNull().WithMessage("É necessário informar o Nome.")
                .Length(3, 100).WithMessage("O campo nome deve ter entre 3 e 100 caracteres");
            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("É necessário informar o Cpf.")
                .NotNull().WithMessage("É necessário informar o Cpf.")
                .IsValidCPF().WithMessage("CPF Invalido!");
            RuleFor(c => c.Rg)
                .NotEmpty().WithMessage("É necessário informar o Rg.")
                .NotNull().WithMessage("É necessário informar o Rg.");
            RuleFor(c => c.Sex)
                .NotEmpty().WithMessage("É necessário informar o Sexo.")
                .NotNull().WithMessage("É necessário informar o Sexo.");
            RuleFor(c => c.BirthDate)
                .NotEmpty().WithMessage("É necessário informar a data de nascimento.")
                .NotNull().WithMessage("É necessário informar data de nascimento.");
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("É necessário informar o Email.")
                .NotNull().WithMessage("É necessário informar o Email.")
                .EmailAddress().WithMessage("E-mail inválido");
        }
    }
}
