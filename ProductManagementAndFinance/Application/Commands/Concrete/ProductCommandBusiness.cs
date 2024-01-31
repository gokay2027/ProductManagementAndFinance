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

        public async Task<AddProductOutputModel> AddProduct(AddProductModel model)
        {
            try
            {
                var product = new Product(model.Name, model.Description, model.Price, model.PriceCurrency);

                await _productRepository.Add(product);

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

        public async Task<DeleteProductOutputModel> DeleteProduct(DeleteProductInputModel model)
        {
            try
            {
                await _productRepository.Delete(model.Id);

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

        public async Task<UpdateProductOutputModel> UpdateProduct(UpdateProductModel model)
        {
            try
            {
                var product = await _productRepository.GetById(model.Id);
                product.SetProduct(model.Name, model.Description, model.Price, model.PriceCurrency, model.CategoryId, model.StorageId);
                await _productRepository.Update(product);
                return new UpdateProductOutputModel
                {
                    IsSuccess = true,
                    Message = "Product Updated Successfully"
                };
            }
            catch (Exception ex)
            {
                return new UpdateProductOutputModel
                {
                    IsSuccess = false,
                    Message = ex.InnerException.Message
                };
            }
        }
    }
}