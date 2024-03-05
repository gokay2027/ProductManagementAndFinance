using ProductManagementAndFinance.Application.Commands.Abstract;
using ProductManagementAndFinance.Application.Commands.Concrete;
using ProductManagementAndFinance.Application.Queries.Abstract;
using ProductManagementAndFinance.Application.Queries.Concrete;
using ProductManagementAndFinance.Models.Command.Product;
using ProductManagementAndFinanceApi.Models.Query.Product;
using ProductManagementAndFinanceData.Repository.EntityRepository;

namespace ProductManagementAndFİnanceTest.CommandTests
{
    public class QueryTest
    {
        private readonly IProductQuery productQuery;
        private readonly IProductCommandBusiness productCommandBusiness;

        public QueryTest()
        {
            var context = new ObjectDatabase.ObjectDatabase();
            var productRepository = new ProductRepository(context.GetProductManagementAndFinanceInMemoryContext());
            productQuery = new ProductQuery(productRepository);
            productCommandBusiness = new ProductCommandBusiness(productRepository);
        }

        [Fact]
        private async void GetAllProductsSuccess()
        {
            await productCommandBusiness.AddProduct(new AddProductModel
            {
                Description = "Test",
                Name = "Test",
                Price = 11,
                PriceCurrency = "TestCurrency"
            });

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