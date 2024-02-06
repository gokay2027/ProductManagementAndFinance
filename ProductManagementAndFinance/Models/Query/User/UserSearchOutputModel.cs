using ProductManagementAndFinance.Models.AbstractOutputModel.Query;

namespace ProductManagementAndFinanceApi.Models.Query.User
{
    public class UserLoginOutputModel : BaseQueryOutputModel
    {
        public UserBaseModel Data { get; set; }
    }

    public class UserSearchOutputModel : BaseQueryOutputModel
    {
        public List<UserBaseModel> OutputList { get; set; } = new List<UserBaseModel>();
    }

    public class UserBaseModel
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
    }
}