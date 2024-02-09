using Microsoft.AspNetCore.Mvc;
using ProductManagementAndFinanceApi.Application.Commands.Abstract;
using ProductManagementAndFinanceApi.Application.Queries.Abstract;
using ProductManagementAndFinanceApi.Models.Command.Storage;
using ProductManagementAndFinanceApi.Models.Query.Storage;

namespace ProductManagementAndFinanceApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StorageController : ControllerBase
    {
        private readonly IStorageQuery _storageQuery;
        private readonly IStorageCommandBusiness _storageCommandBusiness;

        public StorageController(IStorageQuery storageQuery, IStorageCommandBusiness storageCommandBusiness)
        {
            _storageQuery = storageQuery;
            _storageCommandBusiness = storageCommandBusiness;
        }

        [HttpGet]
        public Task<StorageOutputModel> GetAllStorages()
        {
            return _storageQuery.GetAllStorages();
        }

        [HttpGet]
        public Task<StorageOutputModel> GetStoragesByFilter([FromQuery] StorageSearchModel model)
        {
            return _storageQuery.GetStoragesByFilter(model);
        }

        [HttpGet]
        public Task<StorageOutputModel> GetStoragesByProduct([FromQuery] StorageByProductSearchModel model)
        {
            return _storageQuery.GetStoragesByProduct(model);
        }

        [HttpPost]
        public Task<AddStorageOutputModel> AddStorage([FromBody] AddStorageInputModel inputModel)
        {
            return _storageCommandBusiness.AddStorage(inputModel);
        }

        [HttpPut]
        public Task<UpdateStorageOutputModel> UpdateStorage([FromBody] UpdateStorageInputModel inputModel)
        {
            return _storageCommandBusiness.UpdateStorage(inputModel);
        }

        [HttpDelete]
        public Task<DeleteStorageOutputModel> DeleteStorageInputModel([FromBody] DeleteStorageInputModel inputModel)
        {
            return _storageCommandBusiness.DeleteStorage(inputModel);
        }
    }
}