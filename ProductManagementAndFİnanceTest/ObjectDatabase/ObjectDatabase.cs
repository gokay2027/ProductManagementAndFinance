using Entities.ConcreteEntity;
using Microsoft.EntityFrameworkCore;
using ProductManagementAndFinanceData;

namespace ObjectDatabase
{
    public class ObjectDatabase
    {
        public static ProductManagementAndFinanceContext GetMemoryContext()
        {
            var options = new DbContextOptionsBuilder<ProductManagementAndFinanceContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
            .Options;
            return new ProductManagementAndFinanceContext(options);
        }
    }
}