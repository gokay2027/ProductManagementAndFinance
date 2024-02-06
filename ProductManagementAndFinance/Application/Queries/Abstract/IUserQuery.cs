using ProductManagementAndFinanceApi.Models.Query.User;

namespace ProductManagementAndFinanceApi.Application.Queries.Abstract
{
    public interface IUserQuery
    {
        Task<UserLoginOutputModel> Login(UserLoginModel loginModel);

        Task<UserSearchOutputModel> SearchUser(UserSearchModel searchModel);
    }
}