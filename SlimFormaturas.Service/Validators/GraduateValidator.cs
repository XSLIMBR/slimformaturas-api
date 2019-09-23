using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using SlimFormaturas.Domain.Entities;

namespace SlimFormaturas.Service.Validators {
    public class GraduateValidator : AbstractValidator<Graduate> {
        public GraduateValidator() {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x => throw new ArgumentNullException("O objeto não foi encontrado!"));
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("É necessário informar o Nome.")
                .NotNull().WithMessage("É necessário informar o Nome.");
        }
    }
}
