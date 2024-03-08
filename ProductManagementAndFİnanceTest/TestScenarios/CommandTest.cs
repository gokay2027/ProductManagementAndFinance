using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;
using ProductManagementAndFinance.Application.Commands.Abstract;
using ProductManagementAndFinance.Application.Commands.Concrete;
using ProductManagementAndFinanceApi.Application.Commands.Abstract;
using ProductManagementAndFinanceApi.Application.Commands.Concrete;
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
        }



    }
}