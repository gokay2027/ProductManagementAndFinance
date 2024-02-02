using Entities.ConcreteEntity;
using Microsoft.EntityFrameworkCore;
using ProductManagementAndFinanceData.Repository.Contract;
using ProductManagementAndFinanceData.Repository.EntityRepository.Abstract;
using System.Linq.Expressions;

namespace ProductManagementAndFinanceData.Repository.EntityRepository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductManagementAndFinanceContext context) : base(context)
        { }

        private DbSet<Product> Context
        {
            get { return _context.Products; }
        }

        public async Task<IQueryable<Product>> GetFilteredProductsWithCategoryAndStorage(Expression<Func<Product, bool>> predicate)
        {
            return Context.Where(predicate)
                 .Include(a => a.Category)
                 .Include(a => a.Storage);
        }

        public async Task<IQueryable<Product>> GetAllProductsWithCategoryAndStorage()
        {
            return Context.Include(a => a.Category).Include(a => a.Storage);
        }
    }
}