namespace ProductManagementAndFinanceApi.Models.Command.Storage
{
    public class UpdateStorageInputModel
    {
        public Guid Id { get; set; }
        public string? Adress { get; set; }
        public string? Name { get; set; }
        public Guid? UserId { get; set; }
    }
}