using FluentValidation;
using ProductManagementAndFinanceApi.Models.Command.Storage;

namespace ProductManagementAndFinanceApi.Validation.InputModelValidation.Storage
{
    public class UpdateStorageInputModelValidator : AbstractValidator<UpdateStorageInputModel>
    {
        public UpdateStorageInputModelValidator()
        {
            RuleFor(a => a.Id).NotEmpty().WithMessage("Storage field can not be empty");
            RuleFor(a => a.Adress).NotEmpty().WithMessage("Storage adress can not be empty");
            RuleFor(a => a.Name).NotEmpty().WithMessage("Storage name can not be empty");
            RuleFor(a => a.UserId).NotEmpty().WithMessage("Storage owner field can not be empty");
        }
    }
}