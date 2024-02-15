namespace ProductManagementAndFinanceApi.Models.Command.Finance
{
    public class CreateFinanceReportForUserInputModel
    {
        public Guid UserId { get; set; }
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
    }
}