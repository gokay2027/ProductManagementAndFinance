using FluentValidation;
using ProductManagementAndFinanceApi.Models.Query.Product;

namespace ProductManagementAndFinanceApi.Validation.SearchModelValidation.Product
{
    public class ProductByStorageSearchModelValidator : AbstractValidator<ProductByStorageSearchModel>
    {
        public ProductByStorageSearchModelValidator()
        {
        }
    }
}