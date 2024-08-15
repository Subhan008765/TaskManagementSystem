using FluentValidation;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(e => e.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(e => e.Email).EmailAddress().WithMessage("Invalid email format.");
        }
    }
}

