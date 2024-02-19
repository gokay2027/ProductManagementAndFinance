using FluentValidation;
using ProductManagementAndFinance.Models.Command.Product;

namespace ProductManagementAndFinanceApi.Validation.InputModelValidation.Product
{
    public class AddProductInputModelValidator : AbstractValidator<AddProductModel>
    {
        public AddProductInputModelValidator()
        {
        }
    }
}