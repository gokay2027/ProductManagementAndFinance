using FluentValidation;
using ProductManagementAndFinanceApi.Models.Command.Storage;

namespace ProductManagementAndFinanceApi.Validation.InputModelValidation.Storage
{
    public class DeleteStorageInputModelValidator : AbstractValidator<DeleteStorageInputModel>
    {
        public DeleteStorageInputModelValidator()
        {
            RuleFor(a => a.Id).NotEmpty().WithMessage("Storage field can not be empty");
        }
    }
}