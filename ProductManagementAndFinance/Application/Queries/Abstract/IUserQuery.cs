using ProductManagementAndFinanceApi.Models.Query.User;

namespace ProductManagementAndFinanceApi.Application.Queries.Abstract
{
    public interface IUserQuery
    {
        UserSearchOutputModel Login(UserLoginModel loginModel);
        UserSearchOutputModel SearchUser(UserSearchModel searchModel);

    }
}