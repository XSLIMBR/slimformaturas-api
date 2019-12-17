using FluentValidation;
using SlimFormaturas.Domain.Entities;
using System;

namespace SlimFormaturas.Domain.Validators {
    public class AddressValidator : AbstractValidator<Address>{
        public AddressValidator() {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x => throw new ArgumentNullException("O objeto não foi encontrado!"));
            RuleFor(c => c.Cep)
                .NotEmpty().WithMessage("É necessário informar o Cep.")
                .NotNull()
                .Length(8).WithMessage("O campo Cep deve ter 8 caracteres");
            RuleFor(c => c.Street)
                .NotEmpty().WithMessage("É necessário informar a rua.")
                .NotNull()
                .Length(1,50).WithMessage("O campo Rua deve ter no maximo 50 caracteres");
            RuleFor(c => c.Number)
                .NotEmpty().WithMessage("É necessário informar o numero.")
                .NotNull()
                .Length(1,8).WithMessage("O campo numero deve ter no maximo 8 caracteres");
            RuleFor(c => c.Neighborhood)
                .NotEmpty().WithMessage("É necessário informar o bairro.")
                .NotNull()
                .Length(1,50).WithMessage("O campo bairro deve ter no maximo 50 caracteres");
            RuleFor(c => c.Complement)
                .Length(0,50).WithMessage("O campo complemento deve ter no maixmo 50 caracteres");
            RuleFor(c => c.City)
                .NotEmpty().WithMessage("É necessário informar a cidade.")
                .NotNull()
                .Length(1,50).WithMessage("O campo cidade deve ter no maximo 50 caracteres");
            RuleFor(c => c.Uf)
                .NotEmpty().WithMessage("É necessário informar a UF.")
                .NotNull()
                .Length(2).WithMessage("O campo UF deve ter no maximo 2 caracteres");
            RuleFor(c => c.TypeGeneric)
                .NotEmpty().WithMessage("É necessário informar a Tipo.")
                .NotNull();
        }
    }
}
