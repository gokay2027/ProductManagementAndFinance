using ProductManagementAndFinance.Models.AbstractOutputModel.Query;

namespace ProductManagementAndFinanceApi.Models.Query.Storage
{
    public class StorageOutputModel : BaseQueryOutputModel
    {
        public string Adress { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }
}