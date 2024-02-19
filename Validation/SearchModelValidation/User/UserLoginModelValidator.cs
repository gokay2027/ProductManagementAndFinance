using FluentValidation;
using ProductManagementAndFinanceApi.Models.Query.User;

namespace Validation.SearchModelValidation.User
{
    public class UserLoginModelValidator : AbstractValidator<UserLoginModel>
    {
        public UserLoginModelValidator()
        {
            RuleFor(model => model.UserName).NotEmpty().WithMessage("Username can not be empty!");
            RuleFor(model => model.Password).NotEmpty().WithMessage("Password can not be empty!");
        }
    }
}