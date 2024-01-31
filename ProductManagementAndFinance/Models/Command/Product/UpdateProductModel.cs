namespace ProductManagementAndFinance.Models.Command.Product
{
    public class UpdateProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string PriceCurrency { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? StorageId { get; set; }
        public Guid? OrderId { get; set; }
    }
}