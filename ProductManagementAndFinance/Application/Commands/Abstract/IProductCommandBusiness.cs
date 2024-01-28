using ProductManagementAndFinance.Models.Command.Product;

namespace ProductManagementAndFinance.Application.Commands.Abstract
{
    public interface IProductCommandBusiness
    {
        AddProductOutputModel AddProduct(AddProductModel model);

        

    }
}
