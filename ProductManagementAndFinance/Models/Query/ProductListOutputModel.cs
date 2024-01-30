using ProductManagementAndFinance.Models.AbstractOutputModel.Query;

namespace ProductManagementAndFinance.Models.Query
{
    public class ProductOutputModel : BaseQueryOutputModel
    {
        public List<ProductListOutputModel> OutputList { get; set; } = new List<ProductListOutputModel>();
    }

    public class ProductListOutputModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float? Price { get; set; }
        public string PriceCurrency { get; set; }
        public string? StorageName { get; set; }
        public string? CategoryName { get; set; }
    }
}