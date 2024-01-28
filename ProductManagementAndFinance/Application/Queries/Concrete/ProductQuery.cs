using ProductManagementAndFinance.Application.Queries.Abstract;
using ProductManagementAndFinance.Models.Query;
using ProductManagementAndFinanceData.Repository.EntityRepository.Abstract;
using System.Collections.Generic;

namespace ProductManagementAndFinance.Application.Queries.Concrete
{
    public class ProductQuery : IProductQuery
    {
        private readonly IProductRepository _productRepository;

        public ProductQuery(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<GetAllProductsOutputModel>> GetAllProducts()
        {
            try
            {
                var outputList = new List<GetAllProductsOutputModel>();
                var allProducts = await _productRepository.GetAll();

                foreach (var product in allProducts)
                {
                    outputList.Add(new GetAllProductsOutputModel
                    {
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        PriceCurrency = product.PriceCurrency,
                        CategoryName = null,
                        StorageName = null,
                    });
                }
                return outputList;
            }
            catch (Exception ex)
            {
                return new List<GetAllProductsOutputModel>();
            }
        }
    }
}