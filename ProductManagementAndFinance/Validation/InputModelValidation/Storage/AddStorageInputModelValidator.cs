using FluentValidation;
using ProductManagementAndFinanceApi.Models.Command.Storage;

namespace ProductManagementAndFinanceApi.Validation.InputModelValidation.Storage
{
    public class AddStorageInputModelValidator : AbstractValidator<AddStorageInputModel>
    {
        public AddStorageInputModelValidator()
        {
            RuleFor(a => a.Name).MinimumLength(2).NotEmpty().WithMessage("Storage name can not be empty");
            RuleFor(a => a.UserId).NotEmpty().WithMessage("Storage user can not be empty");
            RuleFor(a => a.Adress).NotEmpty().WithMessage("Storage adress can not be empty");
        }
    }
}