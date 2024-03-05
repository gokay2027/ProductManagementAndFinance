using ProductManagementAndFinance.Application.Commands.Abstract;
using ProductManagementAndFinance.Application.Commands.Concrete;
using ProductManagementAndFinance.Application.Queries.Abstract;
using ProductManagementAndFinance.Application.Queries.Concrete;
using ProductManagementAndFinance.Models.Command.Product;
using ProductManagementAndFinanceApi.Models.Query.Product;
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
            var resultAdd = await productCommandBusiness.AddProduct(new AddProductModel
            {
                Description = "Test",
                Name = "Test",
                Price = 11,
                PriceCurrency = "TestCurrency"
            });

            var productOutputModel = productQuery.GetAllProducts().Result;
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