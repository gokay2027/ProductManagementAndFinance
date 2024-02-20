using FluentValidation;
using ProductManagementAndFinance.Models.Command.Product;

namespace ProductManagementAndFinanceApi.Validation.InputModelValidation.Product
{
    public class UpdateProductInputModelValidator : AbstractValidator<UpdateProductModel>
    {
        public UpdateProductInputModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Product name can not be empty");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Product price can not be empty");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Product id can not be empty");
            RuleFor(x => x.PriceCurrency).NotEmpty().WithMessage("Product price currency can not be empty");
        }
    }
}