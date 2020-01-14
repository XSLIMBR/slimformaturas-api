using FluentValidation;
using SlimFormaturas.Domain.Entities;
using System;

namespace SlimFormaturas.Domain.Validators {
    public class EmployeeValidator : AbstractValidator<Employee>{
        public EmployeeValidator() {

        }
    }
}
