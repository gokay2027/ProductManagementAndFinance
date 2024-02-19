using FluentValidation;
using ProductManagementAndFinanceApi.Models.Command.Category;

namespace ProductManagementAndFinanceApi.Validation.InputModelValidation.Category
{
    public class UpdateCategoryModelValidator : AbstractValidator<UpdateCategoryModel>
    {
        public UpdateCategoryModelValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("Name can not be empty");
            RuleFor(a => a.Description).NotEmpty().WithMessage("Description can not be empty");
            RuleFor(a => a.Id).NotEmpty().WithMessage("Id can not be Empty");
        }
    }
}