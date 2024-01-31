using Entities.ConcreteEntity;
using LinqKit;
using Microsoft.IdentityModel.Tokens;
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
                output.ItemCount = allProducts.Count;
                return output;
            }
            catch (Exception ex)
            {
                output.IsSuccess = false;
                output.Message = ex.Message;
                output.ItemCount = 0;
                return output;
            }
        }

        public async Task<ProductOutputModel> GetProductsByFilter(ProductSearchModel searchModel)
        {
            var output = new ProductOutputModel();
            try
            {
                var predicate = FilterBuilderForQuery(searchModel);

                var filteredProducts = await _productRepository.GetByFilter(predicate);

                foreach (var product in filteredProducts)
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
                output.ItemCount = filteredProducts.Count;
                return output;
            }
            catch (Exception ex)
            {
                output.IsSuccess = false;
                output.Message = ex.Message;
                output.ItemCount = 0;
                return output;
            }
        }

        private static ExpressionStarter<Product> FilterBuilderForQuery(ProductSearchModel searchModel)
        {
            var predicate = PredicateBuilder.New<Product>();

            if (!searchModel.Name.IsNullOrEmpty())
                predicate.And(a => a.Name.Contains(searchModel.Name));

            if (!searchModel.Description.IsNullOrEmpty())
                predicate.And(a => a.Description.Contains(searchModel.Description));

            if (!searchModel.PriceCurrency.IsNullOrEmpty())
                predicate.And(a => a.PriceCurrency.Equals(searchModel.PriceCurrency));

            if (searchModel.Price.HasValue)
                predicate.And(a => a.Price.Equals(searchModel.Price));

            if (searchModel.StorageId.HasValue)
                predicate.And(a => a.StorageId.Equals(searchModel.StorageId));

            if (searchModel.CategoryId.HasValue)
                predicate.And(a => a.StorageId.Equals(searchModel.CategoryId));

            return predicate;
        }
    }
}