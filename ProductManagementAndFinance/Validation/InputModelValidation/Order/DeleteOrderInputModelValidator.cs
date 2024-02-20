using FluentValidation;
using ProductManagementAndFinanceApi.Models.Command.Order;

namespace ProductManagementAndFinanceApi.Validation.InputModelValidation.Order
{
    public class DeleteOrderInputModelValidator : AbstractValidator<DeleteOrderInputModel>
    {
        public DeleteOrderInputModelValidator()
        {
            RuleFor(a => a.Id).NotEmpty().WithMessage("Model id can not be empty");
        }
    }
}