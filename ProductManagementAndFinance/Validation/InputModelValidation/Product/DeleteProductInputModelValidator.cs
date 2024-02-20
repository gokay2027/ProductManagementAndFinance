using FluentValidation;
using ProductManagementAndFinance.Models.Command.Product;

namespace ProductManagementAndFinanceApi.Validation.InputModelValidation.Product
{
    public class DeleteProductInputModelValidator : AbstractValidator<DeleteProductInputModel>
    {
        public DeleteProductInputModelValidator()
        {
            RuleFor(a => a.Id).NotEmpty().WithMessage("Product id can not be empty");
        }
    }
}