using ProductManagementAndFinanceApi.Models.Command.User;

namespace ProductManagementAndFinanceApi.Application.Commands.Abstract
{
    public interface IUserCommandBusiness
    {
        /// <summary>
        /// Adds User to the system
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<UserAddCommandOutputModel> AddUser(UserAddInputModel input);

        /// <summary>
        /// Deletes user from the system (changes isActive status)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<UserDeleteCommandOutputModel> DeleteUser(UserDeleteInputModel input);

        /// <summary>
        /// Updates User
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<UserUpdateCommandOutputModel> UpdateUser(UserUpdateInputModel input);

        /// <summary>
        /// Changes password of the user
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<UserChangePasswordCommandOutputModel> ChangePassword(UserChangePasswordInputModel input);
    }
}