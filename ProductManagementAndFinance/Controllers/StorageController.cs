using Microsoft.AspNetCore.Mvc;
using ProductManagementAndFinanceApi.Application.Queries.Abstract;
using ProductManagementAndFinanceApi.Models.Query.Storage;

namespace ProductManagementAndFinanceApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StorageController : ControllerBase
    {
        private readonly IStorageQuery _storageQuery;

        public StorageController(IStorageQuery storageQuery)
        {
            _storageQuery = storageQuery;
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
    }
}