using FluentValidation;
using Manager.Domain.Entities;
namespace Manager.Domain.Validators
{
  public class UserValidator : AbstractValidator<User>
  {
    public UserValidator()
    {
      RuleFor(x => x)
          .NotEmpty()
          .WithMessage("User is not empty")
          .NotNull()
          .WithMessage("User is not null");

      RuleFor(x => x.Name)
          .NotEmpty()
          .WithMessage("Name is not empty")

          .NotNull()
          .WithMessage("Name is not null")

          .MinimumLength(3)
          .WithMessage("Name is minimum 3 characters")

          .MaximumLength(80)
          .WithMessage("Name is maximum 50 characters");

      RuleFor(x => x.Email)
          .NotEmpty()
          .WithMessage("Email is not empty")

          .NotNull()
          .WithMessage("Email is not null")

          .MinimumLength(3)
          .WithMessage("Email is minimum 3 characters")

          .MaximumLength(180)
          .WithMessage("Email is maximum 50 characters")

          .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
          .WithMessage("Email is not valid");

      RuleFor(x => x.Password)
          .NotEmpty()
          .WithMessage("Password is not empty")

          .NotNull()
          .WithMessage("Password is not null")

          .MinimumLength(6)
          .WithMessage("Password is minimum 3 characters")

          .MaximumLength(30)
          .WithMessage("Password is maximum 50 characters");



    }
  }
}