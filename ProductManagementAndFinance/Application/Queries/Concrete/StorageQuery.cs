using Entities.ConcreteEntity;
using LinqKit;
using Microsoft.IdentityModel.Tokens;
using ProductManagementAndFinanceApi.Application.Queries.Abstract;
using ProductManagementAndFinanceApi.Models.Query.Storage;
using ProductManagementAndFinanceData.Repository.EntityRepository.Abstract;

namespace ProductManagementAndFinanceApi.Application.Queries.Concrete
{
    public class StorageQuery : IStorageQuery
    {
        private readonly IStorageRepository _storageRepository;

        public StorageQuery(IStorageRepository storageRepository)
        {
            _storageRepository = storageRepository;
        }

        public async Task<StorageOutputModel> GetAllStorages()
        {
            var output = new StorageOutputModel();
            try
            {
                var allStorages = await _storageRepository.GetAllStoragesWithUser();
                foreach (var storage in allStorages)
                {
                    output.OutputList.Add(new StorageListOutputModel
                    {
                        Id = storage.Id,
                        Adress = storage.Adress,
                        Name = storage.Name,
                        UserId = storage.UserId,
                        UserName = storage.User.Name,
                    });
                }
                output.IsSuccess = true;
                output.Message = "Storages Queried Successfully";
                output.ItemCount = allStorages.Count();
                return output;
            }
            catch (Exception ex)
            {
                output.IsSuccess = false;
                output.Message = ex.Message;
                output.ItemCount = 0;
                return output;
            }
        }

        public async Task<StorageOutputModel> GetStoragesByFilter(StorageSearchModel searchModel)
        {
            var output = new StorageOutputModel();
            var storages = new List<Storage>();
            try
            {
                if (searchModel.Name.IsNullOrEmpty() &&
                    searchModel.Adress.IsNullOrEmpty() &&
                    searchModel.UserName.IsNullOrEmpty()
                    )
                {
                    storages.AddRange(await _storageRepository.GetAllStoragesWithUser());
                }
                else
                {
                    var predicate = FilterBuilderForQuery(searchModel);

                    storages.AddRange(await _storageRepository.GetFilteredStoragesWithUser(predicate));
                }

                foreach (var storage in storages)
                {
                    output.OutputList.Add(new StorageListOutputModel
                    {
                        Id = storage.Id,
                        Adress = storage.Adress,
                        Name = storage.Name,
                        UserId = storage.UserId,
                        UserName = storage.User.Name,
                    });
                }
                output.IsSuccess = true;
                output.Message = "Storages Queried Successfully";
                output.ItemCount = storages.Count();
                return output;
            }
            catch (Exception ex)
            {
                output.IsSuccess = false;
                output.Message = ex.Message;
                output.ItemCount = 0;
                return output;
            }
        }

        private static ExpressionStarter<Storage> FilterBuilderForQuery(StorageSearchModel searchModel)
        {
            var predicate = PredicateBuilder.New<Storage>();

            if (!searchModel.Name.IsNullOrEmpty())
                predicate.And(a => a.Name.Contains(searchModel.Name));

            if (!searchModel.Adress.IsNullOrEmpty())
                predicate.And(a => a.Adress.Contains(searchModel.Adress));

            if (!searchModel.UserName.IsNullOrEmpty())
                predicate.And(a => a.User.Name.Equals(searchModel.UserName));

            return predicate;
        }
    }
}