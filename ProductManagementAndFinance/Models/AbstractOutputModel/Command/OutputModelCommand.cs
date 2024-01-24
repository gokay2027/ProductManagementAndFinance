namespace ProductManagementAndFinance.Models.AbstractOutputModel.Command
{
    public abstract class OutputModelCommand
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}