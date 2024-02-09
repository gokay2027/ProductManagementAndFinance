using ProductManagementAndFinanceApi.Models.Query.User;

namespace ProductManagementAndFinanceApi.Application.Queries.Abstract
{
    public interface IUserQuery
    {
        /// <summary>
        /// login function for user
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        Task<UserLoginOutputModel> Login(UserLoginModel loginModel);


        /// <summary>
        /// Search for user
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        Task<UserSearchOutputModel> SearchUser(UserSearchModel searchModel);
    }
}