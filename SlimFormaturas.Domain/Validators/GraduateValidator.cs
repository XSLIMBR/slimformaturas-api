using FluentValidation;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Validators.Extensions;
using System;

namespace SlimFormaturas.Domain.Validators
{
    public class GraduateValidator : AbstractValidator<Graduate> {
        public GraduateValidator() {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x => throw new ArgumentNullException("O objeto não foi encontrado!"));
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("É necessário informar o Nome.")
                .NotNull()
                .Length(3, 100).WithMessage("O campo nome deve ter entre 3 e 100 caracteres");
            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("É necessário informar o Cpf.")
                .IsValidCPF().WithMessage("CPF Invalido!")
                .Length(11).WithMessage("O campo deve conter 11 caracteres")
                .NotNull();
            RuleFor(c => c.Rg)
                .NotEmpty().WithMessage("É necessário informar o Rg.")
                .NotNull();
            RuleFor(c => c.Sex)
                .NotEmpty().WithMessage("É necessário informar o Sexo.")
                .NotNull();
            RuleFor(c => c.BirthDate)
                .NotEmpty().WithMessage("É necessário informar a data de nascimento.")
                .NotNull();
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("É necessário informar o Email.")
                .EmailAddress().WithMessage("E-mail inválido")
                .NotNull();    
            RuleFor(c => c.DadName)
                .Length(3, 100).WithMessage("O campo nome do pai deve ter entre 3 e 100 caracteres");
            RuleFor(c => c.MotherName)
                .Length(3, 100).WithMessage("O campo nome da mãe deve ter entre 3 e 100 caracteres");
            RuleFor(c => c.Photo)
                .Length(1,255).WithMessage("O campo foto deve conter no maximo 255 caracteres");
            RuleFor(c => c.Bank)
                .Length(1,50).WithMessage("O campo foto deve conter no maximo 50 caracteres");
            RuleFor(c => c.Agency)
                .Length(1,50).WithMessage("O campo foto deve conter no maximo 50 caracteres");
            RuleFor(c => c.CheckingAccount)
                .Length(1,50).WithMessage("O campo foto deve conter no maximo 50 caracteres");
            RuleFor(c => c.Address).NotEmpty().WithMessage("É necessário inserir ao menos 1 endereço").NotNull();
            RuleFor(c => c.Phone).NotEmpty().WithMessage("É necessário inserir ao menos 1 telefone").NotNull();
        }
    }
}
