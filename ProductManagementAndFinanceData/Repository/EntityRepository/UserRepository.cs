using Entities.ConcreteEntity;
using ProductManagementAndFinanceData.Repository.Contract;

namespace ProductManagementAndFinanceData.Repository.EntityRepository
{
    public class UserRepository : EfCoreRepository<User>
    {
        public UserRepository(ProductManagementAndFinanceContext context) : base(context)
        {
        }
    }
}