using FluentValidation;
using mvc_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc_CRUD.Validations
{
    public class EmployeeValidation : AbstractValidator<Employee>
    {
        public EmployeeValidation()
        {
            RuleFor(e => e.FirstName).NotEmpty().Length(0, 8);
            RuleFor(e => e.LastName).NotEmpty().Length(0, 8);
            RuleFor(e => e.Phone).Length(10).WithMessage("Enter valid number");
            RuleFor(s => s.Email).NotEmpty().WithMessage("Email address is required")
                    .EmailAddress().WithMessage("A valid email is required");
        }
    }
}