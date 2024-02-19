using FluentValidation;
using ProductManagementAndFinance.Models.Command.Product;

namespace ProductManagementAndFinanceApi.Validation.InputModelValidation.Product
{
    public class UpdateProductInputModelValidator : AbstractValidator<UpdateProductModel>
    {
        public UpdateProductInputModelValidator()
        {
        }
    }
}