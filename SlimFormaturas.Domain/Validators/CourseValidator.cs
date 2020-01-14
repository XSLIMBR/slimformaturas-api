using System;
using FluentValidation;
using SlimFormaturas.Domain.Entities;

namespace SlimFormaturas.Domain.Validators {
    public class CourseValidator : AbstractValidator<Course>{
        public CourseValidator() {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x => throw new ArgumentNullException("O objeto não foi encontrado!"));
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                .Length(1, 50);
        }
    }
}
