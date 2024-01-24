using Entities.ConcreteEntity;
using ProductManagementAndFinance.Application.Commands.Abstract;
using ProductManagementAndFinance.Models.Command.Product;
using ProductManagementAndFinanceData.Repository.Abstract;

namespace ProductManagementAndFinance.Application.Commands.Concrete
{
    public class ProductCommandBusiness : IProductCommandBusiness
    {
        private readonly IRepository<Product> _productRepository;

        public ProductCommandBusiness(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public AddProductOutputModel AddProduct(AddProductModel model)
        {
            try
            {
                var product = new Product(model.Name, model.Description, model.Price, model.PriceCurrency, model.CategoryId, model.StorageId);

                _productRepository.Add(product);

                return new AddProductOutputModel
                {
                    IsSuccess = true,
                    Message = "Product Added Successfully"
                };
            }
            catch (Exception ex)
            {

                return new AddProductOutputModel
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            } 
            
        }
    }
}