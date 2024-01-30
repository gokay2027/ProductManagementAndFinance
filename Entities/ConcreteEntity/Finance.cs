using Entities.AbstractEntity;

namespace Entities.ConcreteEntity
{
    public class Finance : BaseEntity
    {
        public int TotalSales { get; private set; }
        public float TotalDeby { get; private set; }
        public float TotalProfit { get; private set; }

        public Guid UserId { get; private set; }
        public User User { get; private set; }

        public Finance()
        {
        }

        public Finance(int totalSales, float totalDeby, float totalProfit, Guid userId)
        {
            TotalSales = totalSales;
            TotalDeby = totalDeby;
            TotalProfit = totalProfit;
            UserId = userId;
        }

        public void SetFinance(int totalSales, float totalDeby, float totalProfit, Guid userId)
        {
            TotalSales = totalSales;
            TotalDeby = totalDeby;
            TotalProfit = totalProfit;
            UserId = userId;
            SetUpdateDate();
        }
    }
}