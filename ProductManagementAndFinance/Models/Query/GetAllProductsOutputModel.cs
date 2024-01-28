namespace ProductManagementAndFinance.Models.Query
{
    public class GetAllProductsOutputModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string PriceCurrency { get; set; }
        public string StorageName { get; set; }
        public string CategoryName { get; set; }
    }
}