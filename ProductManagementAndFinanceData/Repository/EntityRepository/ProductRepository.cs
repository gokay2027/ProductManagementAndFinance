using Entities.ConcreteEntity;
using ProductManagementAndFinanceData.Repository.Contract;
using ProductManagementAndFinanceData.Repository.EntityRepository.Abstract;
using System.Data.Entity;

namespace ProductManagementAndFinanceData.Repository.EntityRepository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductManagementAndFinanceContext context) : base(context)
        {
        }
    }
}