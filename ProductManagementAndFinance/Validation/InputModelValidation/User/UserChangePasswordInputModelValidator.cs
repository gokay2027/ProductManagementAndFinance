using FluentValidation;
using ProductManagementAndFinanceApi.Models.Command.User;

namespace Validation.InputModelValidation.User
{
    public class UserChangePasswordInputModelValidator : AbstractValidator<UserChangePasswordInputModel>
    {
        public UserChangePasswordInputModelValidator()
        {
            RuleFor(a => a.NewPassword)
                .NotEmpty()
                .WithMessage("New password can not be empty");

            RuleFor(a => a.OldPassword)
                .NotEmpty()
                .WithMessage("Old password can not be empty");

            RuleFor(a => a.NewPassword)
                .NotEqual(b => b.OldPassword)
                .WithMessage("Old password and New password can not be equal");
        }
    }
}