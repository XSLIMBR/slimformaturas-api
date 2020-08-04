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
                .NotEmpty().WithMessage("É necessário informar o codigo do contrato")
                .NotNull()
                .Length(1, 100);
            RuleFor(c => c.Semester)
                .NotEmpty().WithMessage("É necessário informar o semestre do contrato")
                .NotNull();
            RuleFor(c => c.Year)
                .NotEmpty().WithMessage("É necessário informar o ano do contrato!")
                .NotNull();
        }
    }
}
