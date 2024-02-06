using ProductManagementAndFinance.Models.AbstractOutputModel.Query;
namespace ProductManagementAndFinanceApi.Models.Query.User
{
    public class UserSearchOutputModel : BaseQueryOutputModel
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
    }
}