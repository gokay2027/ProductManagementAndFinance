namespace ProductManagementAndFinanceApi.Models.Command.Finance
{
    public class CreateOrderReportForUserInputModel
    {
        public Guid UserId { get; set; }
        public bool IsDay { get; set; }
        public bool IsWeek { get; set; }
        public bool IsMonth { get; set; }
        public bool IsYear { get; set; }
    }
}