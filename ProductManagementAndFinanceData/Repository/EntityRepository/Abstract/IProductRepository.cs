using Entities.ConcreteEntity;
using ProductManagementAndFinanceData.Repository.Abstract;
using System.Linq.Expressions;

namespace ProductManagementAndFinanceData.Repository.EntityRepository.Abstract
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IQueryable<Product>> GetFilteredProductsWithCategoryAndStorage(Expression<Func<Product, bool>> predicate);

        Task<IQueryable<Product>> GetAllProductsWithCategoryAndStorage();
    }
}