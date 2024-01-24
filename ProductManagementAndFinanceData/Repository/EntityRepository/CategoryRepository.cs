using Entities.ConcreteEntity;
using ProductManagementAndFinanceData.Repository.Contract;

namespace ProductManagementAndFinanceData.Repository.EntityRepository
{
    public class CategoryRepository : EfCoreRepository<Category>
    {
        public CategoryRepository(ProductManagementAndFinanceContext context) : base(context)
        {
        }
    }
}