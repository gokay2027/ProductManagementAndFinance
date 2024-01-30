namespace ProductManagementAndFinance.Models.AbstractOutputModel.Query
{
    public abstract class BaseQueryOutputModel
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}