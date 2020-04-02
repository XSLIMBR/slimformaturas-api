using FluentValidation;
using SlimFormaturas.Domain.Entities;
using System;

namespace SlimFormaturas.Domain.Validators
{
    public class UniversityValidator : AbstractValidator<University>
    {
        public UniversityValidator() 
        {
            RuleFor(c => c)
                 .NotNull()
                 .OnAnyFailure(x => throw new ArgumentNullException("O objeto não foi encontrado!"));

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage(" É necessário informar o nome da Universidade ")
                .NotNull()
                .Length(2, 50).WithMessage("O campo deve ter entre 2 e 50 caracteres ");
        }
    }
}
