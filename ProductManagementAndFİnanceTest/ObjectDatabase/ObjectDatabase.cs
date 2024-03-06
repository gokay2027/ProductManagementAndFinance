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

            DataInMemoryDatabase();
        }

        public ProductManagementAndFinanceContext GetProductManagementAndFinanceInMemoryContext()
        {
            return productManagementAndFinanceInMemoryContext;
        }

        /// <summary>
        /// Test data for in memory database
        /// </summary>
        private void DataInMemoryDatabase()
        {
            var categoryList = new List<Category>()
            {
                new Category("Elektronik Eşya", "Elektronik ve Teknolojik ürünler"),
                new Category("Sağlık", "İlaç ve gıda takviyeleri"),
                new Category("Kozmetik", "Kozmetik ve bakım ürünleri")
            };

            productManagementAndFinanceInMemoryContext.Categories.AddRange(categoryList);
            productManagementAndFinanceInMemoryContext.SaveChanges();
            var userList = new List<User>()
            {
                new User("gokay123", "Gökay", "Dinç", "gokay123@gmail.com", "1234"),
                new User("ayse123", "Ayşe", "AyşeOğlu", "ayse123@gmail.com", "12345"),
                new User("mehmet123", "Mehmet", "MehmetOğlu", "mehet123@gmail.com", "123456")
            };

            productManagementAndFinanceInMemoryContext.Users.AddRange(userList);
            productManagementAndFinanceInMemoryContext.SaveChanges();
            var storageList = new List<Storage>()
            {
                new Storage("Alsancak Gül sokak, 22/35 no:2", "Gökay Storage", productManagementAndFinanceInMemoryContext.Users.First(a => a.Password.Equals("1234")).Id)
            };

            productManagementAndFinanceInMemoryContext.Storages.AddRange(storageList);
            productManagementAndFinanceInMemoryContext.SaveChanges();
            var productList = new List<Product>()
            {
                new Product("Monster T5", "Monster tulpar t5 laptop", 1500, "USD"
                , productManagementAndFinanceInMemoryContext.Categories.First(a => a.Name.Equals("Elektronik Eşya")).Id,
                productManagementAndFinanceInMemoryContext.Storages.First(a => a.Name.Equals("Gökay Storage")).Id),
                new Product("Monster T7", "Monster tulpar t7 laptop", 1700, "USD"
                , productManagementAndFinanceInMemoryContext.Categories.First(a => a.Name.Equals("Elektronik Eşya")).Id,
                productManagementAndFinanceInMemoryContext.Storages.First(a => a.Name.Equals("Gökay Storage")).Id),
                new Product("Casper Nirvana V3", "Casper nirvana laptop", 1100, "USD"
                , productManagementAndFinanceInMemoryContext.Categories.First(a => a.Name.Equals("Sağlık")).Id,
                productManagementAndFinanceInMemoryContext.Storages.First(a => a.Name.Equals("Gökay Storage")).Id),
                new Product("D Vitamini Permidon", "D vitamini takviyesi", 30, "USD"
                , productManagementAndFinanceInMemoryContext.Categories.First(a => a.Name.Equals("Sağlık")).Id,
                productManagementAndFinanceInMemoryContext.Storages.First(a => a.Name.Equals("Gökay Storage")).Id),
                new Product("Arveles", "Arveles ağrı kesici", 15, "USD"
                , productManagementAndFinanceInMemoryContext.Categories.First(a => a.Name.Equals("Sağlık")).Id,
                productManagementAndFinanceInMemoryContext.Storages.First(a => a.Name.Equals("Gökay Storage")).Id),
                new Product("Eyeliner Maybeline", "Eyeliner makyaj malzemesi", 110, "USD"
                , productManagementAndFinanceInMemoryContext.Categories.First(a => a.Name.Equals("Kozmetik")).Id,
                productManagementAndFinanceInMemoryContext.Storages.First(a => a.Name.Equals("Gökay Storage")).Id)
            };

            productManagementAndFinanceInMemoryContext.Products.AddRange(productList);
            productManagementAndFinanceInMemoryContext.SaveChanges();
        }
    }
}