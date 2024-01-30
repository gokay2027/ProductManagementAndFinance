using ProductManagementAndFinance.Models.Query;

namespace ProductManagementAndFinance.Application.Queries.Abstract
{
    public interface IProductQuery
    {
        //Get Products By Filter (Predicate builder)
        //Count products by Filter
        Task<ProductOutputModel> GetAllProducts();


    }
}