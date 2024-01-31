using ProductManagementAndFinance.Models.Command.Product;

namespace ProductManagementAndFinance.Application.Commands.Abstract
{
    public interface IProductCommandBusiness
    {
        /// <summary>
        /// Adds Product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<AddProductOutputModel> AddProduct(AddProductModel model);

        /// <summary>
        /// Deletes Product (Changes the IsActive Status)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<DeleteProductOutputModel> DeleteProduct(DeleteProductInputModel model);

        /// <summary>
        /// Updates Product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<UpdateProductOutputModel> UpdateProduct(UpdateProductModel model);
    }
}