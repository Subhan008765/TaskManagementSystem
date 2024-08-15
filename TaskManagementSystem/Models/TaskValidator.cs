using FluentValidation;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Validators
{
    public class TaskValidator : AbstractValidator<Models.Task>
    {
        public TaskValidator()
        {
            RuleFor(t => t.Title).NotEmpty().WithMessage("Title is required.");
            RuleFor(t => t.DueDate).GreaterThan(DateTime.Now).WithMessage("DueDate must be in the future.");
        }
    }
}
