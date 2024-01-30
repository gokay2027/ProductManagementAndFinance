namespace ProductManagementAndFinance.Models.Query
{
    public class ProductSearchModel
    {
        public string? Name { get;  set; }
        public string? Description { get;  set; }
        public float? Price { get;  set; }
        public string? PriceCurrency { get;  set; }
        public Guid? CategoryId { get;  set; }
        public Guid? StorageId { get; set; }
    }
}
