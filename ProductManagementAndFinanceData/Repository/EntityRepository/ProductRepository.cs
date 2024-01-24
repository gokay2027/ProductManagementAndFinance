using Entities.ConcreteEntity;
using ProductManagementAndFinanceData.Repository.Contract;

namespace ProductManagementAndFinanceData.Repository.EntityRepository
{
    public class ProductRepository : EfCoreRepository<Product>
    {
        public ProductRepository(ProductManagementAndFinanceContext context) : base(context)
        {
        }
    }
}