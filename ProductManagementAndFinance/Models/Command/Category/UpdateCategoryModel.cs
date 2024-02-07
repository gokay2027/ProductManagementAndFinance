namespace ProductManagementAndFinanceApi.Models.Command.Category
{
    public class UpdateCategoryModel
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}