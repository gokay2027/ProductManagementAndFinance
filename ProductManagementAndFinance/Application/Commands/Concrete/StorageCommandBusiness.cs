using Entities.ConcreteEntity;
using ProductManagementAndFinanceApi.Application.Commands.Abstract;
using ProductManagementAndFinanceApi.Models.Command.Storage;
using ProductManagementAndFinanceApi.Validation.InputModelValidation.Storage;
using ProductManagementAndFinanceData.Repository.EntityRepository.Abstract;

namespace ProductManagementAndFinanceApi.Application.Commands.Concrete
{
    public class StorageCommandBusiness : IStorageCommandBusiness
    {
        private readonly IStorageRepository _storageRepository;

        public StorageCommandBusiness(IStorageRepository storageRepository)
        {
            _storageRepository = storageRepository;
        }

        public async Task<AddStorageOutputModel> AddStorage(AddStorageInputModel inputModel)
        {
            var validation = new AddStorageInputModelValidator();
            var validationResult = validation.Validate(inputModel);

            if (validationResult.IsValid)
            {
                try
                {
                    var storage = new Storage(inputModel.Adress, inputModel.Name, inputModel.UserId);
                    await _storageRepository.Add(storage);
                    return new AddStorageOutputModel
                    {
                        IsSuccess = true,
                        Message = "Storage Added Successfully"
                    };
                }
                catch (Exception ex)
                {
                    return new AddStorageOutputModel
                    {
                        IsSuccess = false,
                        Message = ex.Message
                    };
                }
            }
            else
            {
                return new AddStorageOutputModel
                {
                    IsSuccess = false,
                    Message = validationResult.ToString()
                };
            }
        }

        public async Task<DeleteStorageOutputModel> DeleteStorage(DeleteStorageInputModel inputModel)
        {
            var validation = new DeleteStorageInputModelValidator();
            var validationResult = validation.Validate(inputModel);

            if (validationResult.IsValid)
            {
                try
                {
                    await _storageRepository.Delete(inputModel.Id);
                    return new DeleteStorageOutputModel
                    {
                        IsSuccess = true,
                        Message = "Storage Deleted Successfully"
                    };
                }
                catch (Exception ex)
                {
                    return new DeleteStorageOutputModel
                    {
                        IsSuccess = false,
                        Message = ex.Message
                    };
                }
            }
            else
            {
                return new DeleteStorageOutputModel
                {
                    IsSuccess = false,
                    Message = validationResult.ToString()
                };
            }
        }

        public async Task<UpdateStorageOutputModel> UpdateStorage(UpdateStorageInputModel inputModel)
        {
            var validation = new UpdateStorageInputModelValidator();
            var validationResult = validation.Validate(inputModel);

            if (validationResult.IsValid)
            {
                try
                {
                    var storage = await _storageRepository.GetById(inputModel.Id);
                    storage.UpdateStorage(inputModel.Adress, inputModel.Name, inputModel.UserId);
                    await _storageRepository.Update(storage);
                    return new UpdateStorageOutputModel
                    {
                        IsSuccess = true,
                        Message = "Storage Updated Successfully"
                    };
                }
                catch (Exception ex)
                {
                    return new UpdateStorageOutputModel
                    {
                        IsSuccess = false,
                        Message = ex.Message
                    };
                }
            }
            else
            {
                return new UpdateStorageOutputModel
                {
                    IsSuccess = false,
                    Message = validationResult.ToString()
                };
            }
        }
    }
}