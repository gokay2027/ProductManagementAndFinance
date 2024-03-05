using Entities.ConcreteEntity;

namespace ObjectMockDatabase
{
    public class ObjectDatabase
    {

        public static IQueryable<Order> OrderDatabase()
        {
            var orders = new List<Order>();

            #region Data
            #endregion Data

            return orders.AsQueryable();
        }
        public static IQueryable<Storage> StorageDatabase()
        {
            var storages = new List<Storage>();

            #region Data
            #endregion Data

            return storages.AsQueryable();
        }

        public static IQueryable<User> UserDatabase()
        {
            var users = new List<User>();

            #region Data
            #endregion Data

            return users.AsQueryable();
        }

        public static IQueryable<Category> CategoryDatabase()
        {
            var categories = new List<Category>();


            #region Data
            #endregion Data

            return categories.AsQueryable();
        }

        public static IQueryable<Product> ProductDatabase()
        {
            var products = new List<Product>();

            #region Data
            #endregion Data

            return products.AsQueryable();
        }
    }
}