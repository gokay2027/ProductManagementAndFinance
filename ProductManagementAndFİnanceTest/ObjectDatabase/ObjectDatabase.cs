using Entities.ConcreteEntity;
using Microsoft.EntityFrameworkCore;
using ProductManagementAndFinanceData;

namespace ObjectDatabase
{
    public class ObjectDatabase
    {
        private readonly ProductManagementAndFinanceContext productManagementAndFinanceInMemoryContext;

        public ObjectDatabase()
        {
            var builder = new DbContextOptionsBuilder<ProductManagementAndFinanceContext>();
            builder.UseInMemoryDatabase(databaseName: "LibraryDbInMemory");

            var dbContextOptions = builder.Options;
            productManagementAndFinanceInMemoryContext = new ProductManagementAndFinanceContext(dbContextOptions);
            // Delete existing db before creating a new one
            productManagementAndFinanceInMemoryContext.Database.EnsureDeleted();
            productManagementAndFinanceInMemoryContext.Database.EnsureCreated();
        }

        public ProductManagementAndFinanceContext GetProductManagementAndFinanceInMemoryContext()
        {
            return productManagementAndFinanceInMemoryContext;
        }
    }
}