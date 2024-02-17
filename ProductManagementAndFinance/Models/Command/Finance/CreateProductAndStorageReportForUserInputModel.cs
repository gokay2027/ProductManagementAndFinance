namespace ProductManagementAndFinanceApi.Models.Command.Finance
{
    public class CreateProductAndStorageReportForUserInputModel
    {
        public Guid UserId { get; set; }
        public Guid StorageId { get; set; }
    }
}