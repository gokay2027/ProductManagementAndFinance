namespace ProductManagementAndFinanceApi.Models.Command.Order
{
    public class AddOrderInputModel
    {
        public List<Guid> ProductIds { get; set; } = new List<Guid>();
        public string? Adress { get; set; }
        public Guid UserId { get; set; }
    }
}