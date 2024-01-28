using ProductManagementAndFinance.Application.Queries.Abstract;
using ProductManagementAndFinanceData.Repository.EntityRepository.Abstract;

namespace ProductManagementAndFinance.Application.Queries.Concrete
{
    public class ProductQuery : IProductQuery
    {
        private readonly IProductRepository _productRepository;

        public ProductQuery(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }



    }
}