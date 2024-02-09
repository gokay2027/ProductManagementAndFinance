using ProductManagementAndFinanceApi.Models.Command.Storage;

namespace ProductManagementAndFinanceApi.Application.Commands.Abstract
{
    public interface IStorageCommandBusiness
    {
        Task<AddStorageOutputModel> AddStorage(AddStorageInputModel inputModel);

        Task<DeleteStorageOutputModel> DeleteStorage(DeleteStorageInputModel inputModel);

        Task<UpdateStorageOutputModel> UpdateStorage(UpdateStorageInputModel inputModel);
    }
}