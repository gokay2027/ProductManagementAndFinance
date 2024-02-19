using FluentValidation;
using ProductManagementAndFinanceApi.Models.Command.Category;

namespace ProductManagementAndFinanceApi.Validation.InputModelValidation.Category
{
    public class DeleteCategoryModelValidator : AbstractValidator<DeleteCategoryModel>
    {
        public DeleteCategoryModelValidator()
        {
            RuleFor(a => a.Id).NotEmpty().WithMessage("Id can not be empty");
        }
    }
}