using ProductManagementAndFinance.Models.AbstractOutputModel.Query;

namespace ProductManagementAndFinanceApi.Models.Query.Storage
{
    public class StorageOutputModel : BaseQueryOutputModel
    {
        public List<StorageListOutputModel> OutputList { get; set; } = new List<StorageListOutputModel>();
    }

    public class StorageListOutputModel
    {
        public Guid Id { get; set; }
        public string Adress { get; set; }
        public string Name { get; set; }
        public Guid? UserId { get; set; }
        public string? UserName { get; set; }
    }
}