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

        public UserAddCommandOutputModel AddUser(UserAddInputModel input)
        {
            throw new NotImplementedException();
        }

        public UserChangePasswordCommandOutputModel ChangePassword(UserChangePasswordInputModel input)
        {
            throw new NotImplementedException();
        }

        public UserDeleteCommandOutputModel DeleteUser(UserDeleteInputModel input)
        {
            throw new NotImplementedException();
        }

        public UserUpdateCommandOutputModel UpdateUser(UserUpdateInputModel input)
        {
            throw new NotImplementedException();
        }
    }
}