using FluentValidation;
using ProductManagementAndFinance.Models.Command.Product;

namespace ProductManagementAndFinanceApi.Validation.InputModelValidation.Product
{
    public class AddProductInputModelValidator : AbstractValidator<AddProductModel>
    {
        public AddProductInputModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name can not be empty");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price can not be empty");
            RuleFor(x => x.PriceCurrency).NotEmpty().WithMessage("Price currency can not be empty");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category can not be empty");
        }
    }
}