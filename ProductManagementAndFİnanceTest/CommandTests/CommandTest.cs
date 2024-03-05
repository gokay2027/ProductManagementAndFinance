using ObjectDatabase;
using ProductManagementAndFinance.Application.Queries.Abstract;
using ProductManagementAndFinance.Application.Queries.Concrete;
using ProductManagementAndFinanceApi.Models.Query.Product;
using ProductManagementAndFinanceData;
using ProductManagementAndFinanceData.Repository.EntityRepository;
using ProductManagementAndFinanceData.Repository.EntityRepository.Abstract;

namespace ProductManagementAndFİnanceTest.CommandTests
{
    public class QueryTest
    {
        private readonly IProductQuery productQuery;

        public QueryTest()
        {
            var context = ObjectDatabase.ObjectDatabase.GetMemoryContext();
            var productRepository = new ProductRepository(context);
            productQuery = new ProductQuery(productRepository);
        }

        [Fact]
        private async void GetAllProductsSuccess()
        {
            var productOutputModel = await productQuery.GetAllProducts();
            Assert.Equal(true, productOutputModel.IsSuccess);
        }

        [Fact]
        private async void GetProductsByFilter()
        {
            var searchModel = new ProductSearchModel();
            searchModel.Price = 10;
            searchModel.Name = "Diş Fırçası";

            var productsOutputModel = await productQuery.GetProductsByFilter(searchModel);
            Assert.NotEqual(false, productsOutputModel.IsSuccess);
        }
    }
}