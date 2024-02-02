using Entities.ConcreteEntity;
using LinqKit;
using Microsoft.IdentityModel.Tokens;
using ProductManagementAndFinance.Application.Queries.Abstract;
using ProductManagementAndFinance.Models.Query;
using ProductManagementAndFinanceApi.Models.Query;
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

        public async Task<ProductOutputModel> GetAllProducts()
        {
            var output = new ProductOutputModel();
            try
            {
                var allProducts = await _productRepository.GetAllProductsWithCategoryAndStorage();
                foreach (var product in allProducts)
                {
                    output.OutputList.Add(new ProductListOutputModel
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        PriceCurrency = product.PriceCurrency,
                        CategoryName = product.Category == null ? null : product.Category.Name,
                        StorageName = product.Storage == null ? null : product.Storage.Name,
                    });
                }
                output.IsSuccess = true;
                output.Message = "Products Queried Successfully";
                output.ItemCount = allProducts.Count();
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
            var products = new List<Product>();
            try
            {
                if (searchModel.Name.IsNullOrEmpty()
                    && searchModel.Description.IsNullOrEmpty()
                    && !searchModel.Price.HasValue
                    && searchModel.PriceCurrency.IsNullOrEmpty()
                    && !searchModel.CategoryId.HasValue
                    && !searchModel.StorageId.HasValue)
                {
                    products.AddRange(await _productRepository.GetAllProductsWithCategoryAndStorage());
                }
                else
                {
                    var predicate = FilterBuilderForQuery(searchModel);

                    products.AddRange(await _productRepository.GetFilteredProductsWithCategoryAndStorage(predicate));
                }

                foreach (var product in products)
                {
                    output.OutputList.Add(new ProductListOutputModel
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        PriceCurrency = product.PriceCurrency,
                        CategoryName = product.Category == null ? null : product.Category.Name,
                        StorageName = product.Storage == null ? null : product.Storage.Name,
                    });
                }
                output.IsSuccess = true;
                output.Message = "Products Queried Successfully";
                output.ItemCount = products.Count();
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

        public Task<ProductOutputModel> GetProductsByStorage(ProductByStorageSearchModel searchModel)
        {
            throw new NotImplementedException();
        }

        public Task<ProductOutputModel?> GetProductsByCategory(ProductByCategorySearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}