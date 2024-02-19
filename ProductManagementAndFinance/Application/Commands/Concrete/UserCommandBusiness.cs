using Entities.ConcreteEntity;
using ProductManagementAndFinanceApi.Application.Commands.Abstract;
using ProductManagementAndFinanceApi.Models.Command.User;
using ProductManagementAndFinanceData.Repository.EntityRepository.Abstract;
using Validation.InputModelValidation.User;

namespace ProductManagementAndFinanceApi.Application.Commands.Concrete
{
    public class UserCommandBusiness : IUserCommandBusiness
    {
        private readonly IUserRepository _userRepository;

        public UserCommandBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserAddCommandOutputModel> AddUser(UserAddInputModel inputModel)
        {
            var validation = new UserAddInputModelValidator();
            var validationResult = validation.Validate(inputModel);

            if (validationResult.IsValid)
            {
                try
                {
                    var userToBeAdded = new User(inputModel.UserName, inputModel.Name, inputModel.Surname, inputModel.Email, inputModel.Password);
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
            else
            {
                return new UserAddCommandOutputModel()
                {
                    IsSuccess = false,
                    Message = validationResult.ToString()
                };
            }
        }

        public async Task<UserChangePasswordCommandOutputModel> ChangePassword(UserChangePasswordInputModel inputModel)
        {
            var validation = new UserChangePasswordInputModelValidator();
            var validationResult = validation.Validate(inputModel);

            if (validationResult.IsValid)
            {
                try
                {
                    var user = await _userRepository.GetById(inputModel.Id);
                    var isAuthenticated = user.ChangeUserPassword(inputModel.OldPassword, inputModel.NewPassword);

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
            else
            {
                return new UserChangePasswordCommandOutputModel()
                {
                    IsSuccess = false,
                    Message = validationResult.ToString()
                };
            }
        }

        public async Task<UserDeleteCommandOutputModel> DeleteUser(UserDeleteInputModel inputModel)
        {
            var validation = new UserDeleteInputModelValidator();
            var validationResult = validation.Validate(inputModel);

            if (validationResult.IsValid)
            {
                try
                {
                    var user = await _userRepository.GetById(inputModel.Id);
                    user.Delete();
                    await _userRepository.Update(user);
                    return new UserDeleteCommandOutputModel { IsSuccess = true, Message = "User Deleted Successfully" };
                }
                catch (Exception ex)
                {
                    return new UserDeleteCommandOutputModel { IsSuccess = false, Message = ex.Message };
                }
            }
            else
            {
                return new UserDeleteCommandOutputModel()
                {
                    IsSuccess = false,
                    Message = validationResult.ToString()
                };
            }
        }

        public async Task<UserUpdateCommandOutputModel> UpdateUser(UserUpdateInputModel inputModel)
        {
            var validation = new UserUpdateInputModelValidator();

            var validationResult = validation.Validate(inputModel);
            if (validationResult.IsValid)
            {
                try
                {
                    var user = await _userRepository.GetById(inputModel.Id);
                    user.UpdateUser(inputModel.UserName, inputModel.Name, inputModel.Surname, inputModel.Email, inputModel.Password);
                    await _userRepository.Update(user);

                    return new UserUpdateCommandOutputModel { IsSuccess = true, Message = "User has been updated Successfully" };
                }
                catch (Exception ex)
                {
                    return new UserUpdateCommandOutputModel { IsSuccess = false, Message = ex.Message };
                }
            }
            else
            {
                return new UserUpdateCommandOutputModel()
                {
                    IsSuccess = false,
                    Message = validationResult.ToString()
                };
            }
        }
    }
}