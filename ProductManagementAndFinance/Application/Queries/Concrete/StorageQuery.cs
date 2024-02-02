using Entities.ConcreteEntity;
using ProductManagementAndFinanceApi.Application.Queries.Abstract;
using ProductManagementAndFinanceApi.Models.Query.Storage;
using ProductManagementAndFinanceData.Repository.EntityRepository.Abstract;
using System.Linq.Expressions;

namespace ProductManagementAndFinanceApi.Application.Queries.Concrete
{
    public class StorageQuery : IStorageQuery
    {
        private readonly IStorageRepository _storageRepository;

        public StorageQuery(IStorageRepository storageRepository)
        {
            _storageRepository = storageRepository;
        }

        public Task<StorageOutputModel> GetAllStorages()
        {
            throw new NotImplementedException();
        }

        public Task<StorageOutputModel> GetStoragesByFilter(Expression<Func<Storage, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}