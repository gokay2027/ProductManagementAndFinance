namespace ProductManagementAndFinanceApi.Models.Query.Storage
{
    public class StorageSearchModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid? UserId { get; set; }
    }
}