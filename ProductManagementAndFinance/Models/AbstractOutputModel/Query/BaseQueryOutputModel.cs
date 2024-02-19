namespace ProductManagementAndFinance.Models.AbstractOutputModel.Query
{
    public abstract class BaseQueryOutputModel
    {
        public bool? IsSuccess { get; set; }
        public string? Message { get; set; }
        public int? ItemCount { get; set; }
        public List<string> OutputErrorMessages { get; set; } = new List<string>();

    }
}