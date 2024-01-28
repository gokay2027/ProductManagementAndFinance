using Entities.ConcreteEntity;
using ProductManagementAndFinanceData.Repository.Contract;

namespace ProductManagementAndFinanceData.Repository.EntityRepository
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(ProductManagementAndFinanceContext context) : base(context)
        {
        }
    }
}