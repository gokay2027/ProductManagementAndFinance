using ProductManagementAndFinance.Application.Commands.Abstract;
using ProductManagementAndFinance.Application.Commands.Concrete;
using ProductManagementAndFinance.Application.Queries.Abstract;
using ProductManagementAndFinance.Application.Queries.Concrete;
using ProductManagementAndFinance.Models.Command.Product;
using ProductManagementAndFinanceApi.Application.Commands.Abstract;
using ProductManagementAndFinanceApi.Application.Commands.Concrete;
using ProductManagementAndFinanceApi.Application.Queries.Abstract;
using ProductManagementAndFinanceApi.Application.Queries.Concrete;
using ProductManagementAndFinanceApi.Models.Command.Category;
using ProductManagementAndFinanceApi.Models.Command.Storage;
using ProductManagementAndFinanceApi.Models.Command.User;
using ProductManagementAndFinanceApi.Models.Query.Storage;
using ProductManagementAndFinanceData.Repository.EntityRepository;

namespace ProductManagementAndFinanceTest.TestScenarios
{
    public class CommandTest
    {
        private readonly IProductCommandBusiness productCommandbusiness;
        private readonly ICategoryCommandBusiness categoryCommandBusiness;
        private readonly IStorageCommandBusiness storageCommandBusiness;
        private readonly IOrderCommandBusiness orderCommandBusiness;
        private readonly IUserCommandBusiness userCommandBusiness;

        private readonly ICategoryQuery categoryQuery;
        private readonly IStorageQuery storageQuery;
        private readonly IProductQuery productQuery;

        public CommandTest()
        {
            var objectDatabase = new ObjectDatabase.ObjectDatabase();
            var context = objectDatabase.GetProductManagementAndFinanceInMemoryContext();

            var productRepository = new ProductRepository(context);
            var categoryRepository = new CategoryRepository(context);
            var orderRepository = new OrderRepository(context);
            var storageRepository = new StorageRepository(context);
            var userRepository = new UserRepository(context);

            productCommandbusiness = new ProductCommandBusiness(productRepository);
            categoryCommandBusiness = new CategoryCommandBusiness(categoryRepository);
            storageCommandBusiness = new StorageCommandBusiness(storageRepository);
            orderCommandBusiness = new OrderCommandBusiness(orderRepository, productRepository);
            userCommandBusiness = new UserCommandBusiness(userRepository);

            categoryQuery = new CategoryQuery(categoryRepository);
            storageQuery = new StorageQuery(storageRepository, productRepository);
            productQuery = new ProductQuery(productRepository);
        }

        [Fact]
        private async Task RegisterUserSuccessTest()
        {
            var newUserModel = new UserAddInputModel()
            {
                Name = "Ali",
                Surname = "Veli",
                Email = "ali123@email.com",
                Password = "1234",
                UserName = "ali123"
            };
            var newUserResultModel = await userCommandBusiness.AddUser(newUserModel);

            Assert.True(newUserResultModel.IsSuccess);
        }

        [Fact]
        private async Task RegisterUserFailTest()
        {
            var newUserModel = new UserAddInputModel()
            {
                Name = "",
                Surname = "",
                Email = "ali123@email.com",
                Password = "1234",
                UserName = "ali123"
            };
            var newUserResultModel = await userCommandBusiness.AddUser(newUserModel);

            Assert.False(newUserResultModel.IsSuccess);
        }

        [Fact]
        private async Task AddProductSuccessTest()
        {
            var addProductResult = await productCommandbusiness.AddProduct(new AddProductModel
            {
                Name = "Iphone",
                CategoryId = Guid.NewGuid(),
                Description = "Test Iphone description",
                Price = 22,
                PriceCurrency = "Test currency",
                StorageId = Guid.NewGuid()
            });

            Assert.True(addProductResult.IsSuccess);
        }

        [Fact]
        private async Task AddProductFailTest()
        {
            var addProductResult = await productCommandbusiness.AddProduct(new AddProductModel
            {
                Name = "",
                CategoryId = new Guid(),
                Description = null,
                Price = 22,
                PriceCurrency = "Test currency",
                StorageId = new Guid(),
            });

            Assert.False(addProductResult.IsSuccess);
        }

        [Fact]
        private async Task AddCategorySuccessTest()
        {
            var categoryAddResult = await categoryCommandBusiness.AddCategory(new AddCategoryModel
            {
                Name = "Test Category",
                Description = "Test category description"
            });
            Assert.True(categoryAddResult.IsSuccess);
        }

        [Fact]
        private async Task DeleteCategorySuccessTest()
        {
            var categoryToBeDeleted = await categoryQuery.GetCategoriesByFilter(new ProductManagementAndFinanceApi.Models.Query.Category.CategorySearchModel
            {
                Name = "Sağlık"
            });

            var categoryDeleteResult = await categoryCommandBusiness.DeleteCategory(new DeleteCategoryModel
            {
                Id = categoryToBeDeleted.List.First().Id
            });

            Assert.True(categoryDeleteResult.IsSuccess);
        }

        [Fact]
        private async Task AddStorageSuccessTest()
        {
            var storageAddResult = await storageCommandBusiness.AddStorage(new AddStorageInputModel
            {
                Adress = "Ankara çankaya ali caddesi",
                Name = "Ankarali deposu",
                UserId = Guid.NewGuid(),
            });

            Assert.True(storageAddResult.IsSuccess);
        }

        [Fact]
        private async Task DeleteStorage()
        {
            var storageresult = await storageQuery.GetStoragesByFilter(new StorageSearchModel
            {
                Name = "Gökay Stor",
            });

            var storage = storageresult.OutputList.First();

            var deleteResult = await storageCommandBusiness.DeleteStorage(new DeleteStorageInputModel
            {
                Id = storage.Id
            });

            Assert.True(deleteResult.IsSuccess);
        }

        [Fact]
        private async Task UpdateStorage()
        {
            var storageresult = await storageQuery.GetStoragesByFilter(new StorageSearchModel
            {
                Name = "Gökay Stor",
            });

            var storage = storageresult.OutputList.First();

            var upmodel = new UpdateStorageInputModel
            {
                Id = storage.Id,
                Adress = storage.Adress,
                Name = "GÖKAYY DEPO",
                UserId = storage.UserId
            };
            var updateResult = await storageCommandBusiness.UpdateStorage(upmodel);

            var storageUpdatedresult = await storageQuery.GetStoragesByFilter(new StorageSearchModel
            {
                Name = "GÖKAYY DEPO",
            });

            var storageUpdated = storageUpdatedresult.OutputList.First();

            Assert.True(updateResult.IsSuccess);
            Assert.Equal("GÖKAYY DEPO", storageUpdated.Name);
        }
    }
}