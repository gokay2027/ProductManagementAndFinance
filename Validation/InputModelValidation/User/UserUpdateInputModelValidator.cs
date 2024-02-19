﻿using FluentValidation;
using ProductManagementAndFinanceApi.Models.Command.User;

namespace Validation.InputModelValidation.User
{
    public class UserUpdateInputModelValidator : AbstractValidator<UserUpdateInputModel>
    {
        public UserUpdateInputModelValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("Name can not be empty");
            RuleFor(a => a.Surname).NotEmpty().WithMessage("Surname can not be empty");
            RuleFor(a => a.UserName).NotEmpty().WithMessage("UserName can not be empty");
            RuleFor(a => a.Email).NotEmpty().WithMessage("Email can not be empty");
            RuleFor(a => a.Password).NotEmpty().WithMessage("Password can not be empty");
        }
    }
}