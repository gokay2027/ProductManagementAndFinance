using ProductManagementAndFinance.Application.Queries.Abstract;
using ProductManagementAndFinance.Application.Queries.Concrete;
using ProductManagementAndFinanceApi.Application.Queries.Abstract;
using ProductManagementAndFinanceApi.Application.Queries.Concrete;
using ProductManagementAndFinanceApi.Models.Query.Category;
using ProductManagementAndFinanceApi.Models.Query.Product;
using ProductManagementAndFinanceApi.Models.Query.Storage;
using ProductManagementAndFinanceApi.Models.Query.User;
using ProductManagementAndFinanceData.Repository.EntityRepository;

namespace ProductManagementAndFİnanceTest.CommandTests
{
    /// <summary>
    /// there was no error on testing structure,
    /// just we need to add a data to see the result
    /// before we build the test project, we also need to see the
    /// results of validation to check the test success
    /// </summary>

    public class QueryTest
    {
        private readonly IProductQuery productQuery;
        private readonly ICategoryQuery categoryQuery;
        private readonly IOrderQuery orderQuery;
        private readonly IStorageQuery storageQuery;
        private readonly IUserQuery userQuery;

        public QueryTest()
        {
            var context = new ObjectDatabase.ObjectDatabase();
            var inMemoryDatabase = context.GetProductManagementAndFinanceInMemoryContext();

            var productRepository = new ProductRepository(inMemoryDatabase);
            var categoryRepository = new CategoryRepository(inMemoryDatabase);
            var orderRepository = new OrderRepository(inMemoryDatabase);
            var storageRepository = new StorageRepository(inMemoryDatabase);
            var userRepository = new UserRepository(inMemoryDatabase);

            productQuery = new ProductQuery(productRepository);
            categoryQuery = new CategoryQuery(categoryRepository);
            orderQuery = new OrderQuery(orderRepository);
            storageQuery = new StorageQuery(storageRepository, productRepository);
            userQuery = new UserQuery(userRepository);
        }

        [Fact]
        private async Task GetAllProductsSuccess()
        {
            var productOutputModel = productQuery.GetAllProducts().Result;
            Assert.True(productOutputModel.IsSuccess);
        }

        [Fact]
        private async Task GetProductsByFilterSuccess()
        {
            var searchModel = new ProductSearchModel();
            searchModel.Price = 10;
            searchModel.Name = "Diş Fırçası";

            var productsOutputModel = await productQuery.GetProductsByFilter(searchModel);
            Assert.True(productsOutputModel.IsSuccess);
        }

        [Fact]
        private async Task GetAllCategoriesSuccess()
        {
            var allCategories = await categoryQuery.GetAllCategories();
            Assert.True(allCategories.IsSuccess);
        }

        [Fact]
        private async Task GetCategoriesByFilterSuccess()
        {
            var categories = await categoryQuery.GetCategoriesByFilter(new CategorySearchModel
            {
                Name = "Sağlık"
            });
            Assert.True(categories.IsSuccess);
        }

        [Fact]
        private async Task LoginUserFail()
        {
            var user = await userQuery.Login(new UserLoginModel { UserName = "", Password = null });
            Assert.Null(user.Data);
            Assert.False(user.IsSuccess);
        }

        [Fact]
        private async Task LoginUserSuccess()
        {
            var loginModel = new UserLoginModel { UserName = "gokay123", Password = "1234" };
            var user = await userQuery.Login(loginModel);
            Assert.NotNull(user.Data);
            Assert.True(user.IsSuccess);
        }

        [Fact]
        private async Task GetAllStoragesSuccess()
        {
            var storages = await storageQuery.GetAllStorages();
            Assert.True(storages.IsSuccess);
            Assert.NotEmpty(storages.OutputList);
        }

        [Fact]
        private async Task GetStoargesByFilterSuccess()
        {
            var storageSearchModel = new StorageSearchModel
            {
                Name = "Gökay st"
            };
            var storages = await storageQuery.GetStoragesByFilter(storageSearchModel);
            Assert.True(storages.IsSuccess);
            Assert.NotEmpty(storages.OutputList);
        }
    }
}