using FluentValidation;
using SlimFormaturas.Domain.Entities;
using System;

namespace SlimFormaturas.Domain.Validators {
    public class ShippingCompanyValidator : AbstractValidator<ShippingCompany> {
        public ShippingCompanyValidator () {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x => throw new ArgumentNullException("O objeto não foi encontrado!"));
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("É necessário informar o Nome.")
                .NotNull()
                .Length(3, 100).WithMessage("O campo nome deve ter entre 3 e 100 caracteres");
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("É necessário informar o Email.")
                .EmailAddress().WithMessage("E-mail inválido")
                .NotNull();
            RuleFor(c => c.Bank)
                .Length(1, 50).WithMessage("O campo foto deve conter no maximo 50 caracteres");
            RuleFor(c => c.Agency)
                .Length(1, 50).WithMessage("O campo foto deve conter no maximo 50 caracteres");
            RuleFor(c => c.CheckingAccount)
                .Length(1, 50).WithMessage("O campo foto deve conter no maximo 50 caracteres");
            RuleFor(c => c.Address).NotEmpty().WithMessage("É necessário inserir ao menos 1 endereço").NotNull();
            RuleFor(c => c.Phone).NotEmpty().WithMessage("É necessário inserir ao menos 1 telefone").NotNull();
        }
    }
}
