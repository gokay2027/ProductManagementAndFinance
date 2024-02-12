namespace ProductManagementAndFinanceApi.Models.Command.Finance
{
    public class CreateProductAndStorageReportForUserInputModel
    {
        public Guid UserId { get; set; }
        public bool IsDay { get; set; }
        public bool IsWeek { get; set; }
        public bool IsMonth { get; set; }
        public bool IsYear { get; set; }
        public Guid StorageId { get; set; }
        public Guid ProductId { get; set; }
    }
}