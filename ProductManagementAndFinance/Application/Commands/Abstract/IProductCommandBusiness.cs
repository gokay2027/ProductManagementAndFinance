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
        AddProductOutputModel AddProduct(AddProductModel model);

        /// <summary>
        /// Deletes Product (Changes the IsActive Status)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        DeleteProductOutputModel DeleteProduct(DeleteProductInputModel model);

        /// <summary>
        /// Updates Product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        UpdateProductOutputModel UpdateProduct(UpdateProductModel model);
    }
}