namespace ProductManagementAndFinanceApi.Models.Command.Finance
{
    public class CreateOrderReportForUserInputModel
    {
        public Guid UserId { get; set; }
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
    }
}