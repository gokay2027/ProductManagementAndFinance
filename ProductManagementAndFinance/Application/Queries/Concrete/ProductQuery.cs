using ProductManagementAndFinance.Application.Queries.Abstract;
using ProductManagementAndFinance.Models.Query;
using ProductManagementAndFinanceData.Repository.EntityRepository.Abstract;

namespace ProductManagementAndFinance.Application.Queries.Concrete
{
    public class ProductQuery : IProductQuery
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IStorageRepository _storageRepository;

        public ProductQuery(IProductRepository productRepository, ICategoryRepository categoryRepository, IStorageRepository storageRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _storageRepository = storageRepository;
        }

        public async Task<ProductOutputModel> GetAllProducts()
        {
            var output = new ProductOutputModel();

            try
            {
                var allProducts = await _productRepository.GetAll();

                foreach (var product in allProducts)
                {
                    var categoryOfProduct = await _categoryRepository.GetById(product.CategoryId);
                    var storageOfProduct = await _storageRepository.GetById(product.CategoryId);

                    output.OutputList.Add(new ProductListOutputModel
                    {
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        PriceCurrency = product.PriceCurrency,
                        CategoryName = categoryOfProduct == null ? null : categoryOfProduct.Name,
                        StorageName = storageOfProduct == null ? null : storageOfProduct.Name,
                    });
                }
                output.IsSuccess = true;
                output.Message = "Products Queried Successfully";
                return output;
            }
            catch (Exception ex)
            {
                output.IsSuccess = false;
                output.Message = ex.Message;
                return output;
            }
        }
    }
}