using FluentValidation;
using ProductManagementAndFinanceApi.Models.Command.Order;

namespace ProductManagementAndFinanceApi.Validation.InputModelValidation.Order
{
    public class AddOderInputModelValidator : AbstractValidator<AddOrderInputModel>
    {
        public AddOderInputModelValidator()
        {
            RuleFor(a => a.Adress).NotEmpty().WithMessage("Address field can not be empty!");
            RuleFor(a => a.UserId).NotEmpty().WithMessage("User information can not be empty");
        }
    }
}