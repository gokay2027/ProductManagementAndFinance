using Entities.ConcreteEntity;
using ProductManagementAndFinance.Application.Commands.Abstract;
using ProductManagementAndFinance.Models.Command.Product;
using ProductManagementAndFinanceData.Repository.EntityRepository.Abstract;

namespace ProductManagementAndFinance.Application.Commands.Concrete
{
    public class ProductCommandBusiness : IProductCommandBusiness
    {
        private readonly IProductRepository _productRepository;

        public ProductCommandBusiness(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public AddProductOutputModel AddProduct(AddProductModel model)
        {
            try
            {
                var product = new Product(model.Name, model.Description, model.Price, model.PriceCurrency);

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

        public DeleteProductOutputModel DeleteProduct(DeleteProductInputModel model)
        {
            try
            {
                _productRepository.Delete(model.Id);

                return new DeleteProductOutputModel
                {
                    IsSuccess = true,
                    Message = "Product Added Successfully"
                };
            }
            catch (Exception ex)
            {
                return new DeleteProductOutputModel
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public UpdateProductOutputModel UpdateProduct(UpdateProductModel model)
        {
            var product = _productRepository.GetById();
            throw new NotImplementedException();
        }
    }
}