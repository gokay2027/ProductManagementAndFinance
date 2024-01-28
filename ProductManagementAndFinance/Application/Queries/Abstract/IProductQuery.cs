using ProductManagementAndFinance.Models.Query;

namespace ProductManagementAndFinance.Application.Queries.Abstract
{
    public interface IProductQuery
    {
        Task<List<GetAllProductsOutputModel>> GetAllProducts();
    }
}