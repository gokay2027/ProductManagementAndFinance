using FluentValidation;
using ProductManagementAndFinanceApi.Models.Command.Order;

namespace ProductManagementAndFinanceApi.Validation.InputModelValidation.Order
{
    public class UpdateOrderInputModelValidator : AbstractValidator<UpdateOrderInputModel>
    {
        public UpdateOrderInputModelValidator()
        {
            RuleFor(a => a.Adress).NotEmpty().WithMessage("Adress field can not be empty");
            RuleFor(a => a.TotalPrice).NotEmpty().WithMessage("Total price can not be empty");
            RuleFor(a => a.UserId).NotEmpty().WithMessage("User field can not be empty");
            RuleFor(a => a.Products).NotEmpty().WithMessage("Product list can not be empty");
        }
    }
}