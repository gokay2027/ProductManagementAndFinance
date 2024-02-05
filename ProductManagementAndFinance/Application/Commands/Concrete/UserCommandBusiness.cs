using Entities.ConcreteEntity;
using ProductManagementAndFinanceApi.Application.Commands.Abstract;
using ProductManagementAndFinanceApi.Models.Command.User;
using ProductManagementAndFinanceData.Repository.EntityRepository.Abstract;

namespace ProductManagementAndFinanceApi.Application.Commands.Concrete
{
    public class UserCommandBusiness : IUserCommandBusiness
    {
        private readonly IUserRepository _userRepository;

        public UserCommandBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserAddCommandOutputModel> AddUser(UserAddInputModel input)
        {
            try
            {
                var userToBeAdded = new User(input.UserName, input.Name, input.Surname, input.Email, input.Password);
                await _userRepository.Add(userToBeAdded);
                return new UserAddCommandOutputModel
                {
                    IsSuccess = true,
                    Message = "User has been added successfully"
                };
            }
            catch (Exception ex)
            {
                return new UserAddCommandOutputModel()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<UserChangePasswordCommandOutputModel> ChangePassword(UserChangePasswordInputModel input)
        {
            try
            {
                var user = await _userRepository.GetById(input.Id);
                var isAuthenticated = user.ChangeUserPassword(input.OldPassword, input.NewPassword);

                if (isAuthenticated)
                {
                    await _userRepository.Update(user);
                    return new UserChangePasswordCommandOutputModel
                    {
                        IsSuccess = true,
                        Message = "User password changed successfully"
                    };
                }
                else
                {
                    return new UserChangePasswordCommandOutputModel
                    {
                        IsSuccess = true,
                        Message = "User password can not be changed (passwords do not match)"
                    };
                }
            }
            catch (Exception ex)
            {
                return new UserChangePasswordCommandOutputModel
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<UserDeleteCommandOutputModel> DeleteUser(UserDeleteInputModel input)
        {
            try
            {
                var user = await _userRepository.GetById(input.Id);
                user.Delete();
                await _userRepository.Update(user);
                return new UserDeleteCommandOutputModel { IsSuccess = true, Message = "User Deleted Successfully" };
            }
            catch (Exception ex)
            {
                return new UserDeleteCommandOutputModel { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<UserUpdateCommandOutputModel> UpdateUser(UserUpdateInputModel input)
        {
            try
            {
                var user = await _userRepository.GetById(input.Id);
                user.UpdateUser(input.UserName, input.Name, input.Surname, input.Email, input.Password);
                await _userRepository.Update(user);

                return new UserUpdateCommandOutputModel { IsSuccess = true, Message = "User has been updated Successfully" };
            }
            catch (Exception ex)
            {
                return new UserUpdateCommandOutputModel { IsSuccess = false, Message = ex.Message };
            }
        }
    }
}