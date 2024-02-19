using FluentValidation;
using ProductManagementAndFinanceApi.Models.Command.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation.InputModelValidation.User
{
    public class UserDeleteInputModelValidator:AbstractValidator<UserDeleteInputModel>
    {
        public UserDeleteInputModelValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("User id can not be empty");
        }
    }
}
