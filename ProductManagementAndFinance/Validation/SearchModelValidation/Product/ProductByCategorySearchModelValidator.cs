using FluentValidation;
using ProductManagementAndFinanceApi.Models.Query.Product;

namespace ProductManagementAndFinanceApi.Validation.SearchModelValidation.Product
{
    public class ProductByCategorySearchModelValidator : AbstractValidator<ProductByCategorySearchModel>
    {
        public ProductByCategorySearchModelValidator()
        {
        }
    }
}