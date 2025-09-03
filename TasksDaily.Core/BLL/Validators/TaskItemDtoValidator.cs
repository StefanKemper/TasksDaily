using FluentValidation;

namespace TasksDaily.Core.BLL.Validators
{
  public class TaskItemDtoValidator : AbstractValidator<Dto.TaskItemDto>
  {
    public TaskItemDtoValidator()
    {
      RuleFor(x => x.Title)
        .NotEmpty().WithMessage("Title is required.")
        .MaximumLength(250).WithMessage("Title must not exceed 250 characters.");
      RuleFor(x => x.Description)
        .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters.");
      RuleFor(x => x.DueDate)
        .GreaterThanOrEqualTo(DateTime.Today).When(x => x.DueDate.HasValue)
        .WithMessage("Due date must be today or in the future.");
      RuleFor(x => x.CategoryId)
        .GreaterThan(0).WithMessage("CategoryId must be a positive integer.");
    }
  }
}
