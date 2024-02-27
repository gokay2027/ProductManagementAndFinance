using Entities.ConcreteEntity;
using ProductManagementAndFinance.Application.Commands.Abstract;
using ProductManagementAndFinance.Models.Command.Product;
using ProductManagementAndFinanceApi.Validation.InputModelValidation.Product;
using ProductManagementAndFinanceData.Repository.EntityRepository.Abstract;
using System.Diagnostics;

namespace ProductManagementAndFinance.Application.Commands.Concrete
{
    public class ProductCommandBusiness : IProductCommandBusiness
    {
        private readonly IProductRepository _productRepository;

        public ProductCommandBusiness(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<AddProductOutputModel> AddProduct(AddProductModel inputModel)
        {
            var validation = new AddProductInputModelValidator();
            var validationResult = validation.Validate(inputModel);

            if (validationResult.IsValid)
            {
                try
                {
                    var product = new Product(inputModel.Name, inputModel.Description, inputModel.Price, inputModel.PriceCurrency,inputModel.CategoryId,inputModel.StorageId);

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
            else
            {
                return new AddProductOutputModel
                {
                    IsSuccess = false,
                    Message = validationResult.ToString()
                };
            }
        }

        public async Task<DeleteProductOutputModel> DeleteProduct(DeleteProductInputModel modelModel)
        {
            var validation = new DeleteProductInputModelValidator();
            var validationResult = validation.Validate(modelModel);

            if (validationResult.IsValid)
            {
                try
                {
                    await _productRepository.Delete(modelModel.Id);

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
            else
            {
                return new DeleteProductOutputModel
                {
                    IsSuccess = false,
                    Message = validationResult.ToString(),
                };
            }
        }

        public async Task<UpdateProductOutputModel> UpdateProduct(UpdateProductModel inputModel)
        {
            var validation = new UpdateProductInputModelValidator();

            var validationResult = validation.Validate(inputModel);

            if (validationResult.IsValid)
            {
                try
                {
                    var product = await _productRepository.GetById(inputModel.Id);

                    product.SetProduct(inputModel.Name, inputModel.Description, inputModel.Price, inputModel.PriceCurrency, inputModel.CategoryId, inputModel.StorageId);

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
            else
            {
                return new UpdateProductOutputModel
                {
                    IsSuccess = false,
                    Message = validationResult.ToString()
                };
            }
        }
    }
}