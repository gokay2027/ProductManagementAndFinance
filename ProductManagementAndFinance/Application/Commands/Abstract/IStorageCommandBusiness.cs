using ProductManagementAndFinanceApi.Models.Command.Storage;

namespace ProductManagementAndFinanceApi.Application.Commands.Abstract
{
    public interface IStorageCommandBusiness
    {
        /// <summary>
        /// Adding storage
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        Task<AddStorageOutputModel> AddStorage(AddStorageInputModel inputModel);

        /// <summary>
        /// Delete storage
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        Task<DeleteStorageOutputModel> DeleteStorage(DeleteStorageInputModel inputModel);

        /// <summary>
        /// Update storage
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        Task<UpdateStorageOutputModel> UpdateStorage(UpdateStorageInputModel inputModel);
    }
}