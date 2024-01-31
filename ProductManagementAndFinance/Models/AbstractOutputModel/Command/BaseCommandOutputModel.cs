namespace ProductManagementAndFinance.Models.AbstractOutputModel.Command
{
    public abstract class BaseCommandOutputModel
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}