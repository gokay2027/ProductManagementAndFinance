namespace ProductManagementAndFinance.Models.AbstractOutputModel.Query
{
    public abstract class OutputModelQuery
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}