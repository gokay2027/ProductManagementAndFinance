using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;
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
using ProductManagementAndFinanceApi.Models.Command.User;
using ProductManagementAndFinanceData.Repository.EntityRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }
}