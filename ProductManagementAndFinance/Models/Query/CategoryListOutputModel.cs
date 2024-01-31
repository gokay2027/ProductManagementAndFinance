using ProductManagementAndFinance.Models.AbstractOutputModel.Query;

namespace ProductManagementAndFinance.Models.Query
{
    public class CategoryListOutputModel : BaseQueryOutputModel
    {
        public List<CategoryListModel> List { get; set; } = new List<CategoryListModel>();
    }

    public class CategoryListModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}