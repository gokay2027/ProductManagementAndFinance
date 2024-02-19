using Entities.ConcreteEntity;
using LinqKit;
using Microsoft.IdentityModel.Tokens;
using ProductManagementAndFinanceApi.Application.Queries.Abstract;
using ProductManagementAndFinanceApi.Models.Query.User;
using ProductManagementAndFinanceData.Repository.EntityRepository.Abstract;
using Validation.SearchModelValidation.User;

namespace ProductManagementAndFinanceApi.Application.Queries.Concrete
{
    public class UserQuery : IUserQuery
    {
        private readonly IUserRepository _userRepository;

        public UserQuery(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserLoginOutputModel> Login(UserLoginModel loginModel)
        {
            var validator = new UserLoginModelValidator();
            var validationResult = validator.Validate(loginModel);

            if (validationResult.IsValid)
            {
                try
                {
                    var user = await _userRepository.GetByFilter(a => a.UserName.Equals(loginModel.UserName) && a.Password.Equals(loginModel.Password));

                    if (user.Count().Equals(0))
                    {
                        return new UserLoginOutputModel
                        {
                            ItemCount = 0,
                            IsSuccess = true,
                            Message = "Wrong user information.",
                        };
                    }
                    else
                    {
                        var loggedinUSer = user.ElementAt(0);
                        return new UserLoginOutputModel
                        {
                            Data = new UserBaseModel
                            {
                                Id = loggedinUSer.Id,
                                UserName = loggedinUSer.UserName,
                                Name = loggedinUSer.Name,
                                Surname = loggedinUSer.Surname,
                                Email = loggedinUSer.Email,
                            },
                            ItemCount = 1,
                            IsSuccess = true,
                            Message = "Successfully Logged In",
                        };
                    }
                }
                catch (Exception ex)
                {
                    return new UserLoginOutputModel
                    {
                        ItemCount = 0,
                        IsSuccess = false,
                        Message = ex.Message,
                    };
                }
            }
            else
            {
               

                return new UserLoginOutputModel
                {
                    ItemCount = 0,
                    IsSuccess = false,
                    Message = validationResult.ToString(),
                };
            }
        }

        public async Task<UserSearchOutputModel> SearchUser(UserSearchModel searchModel)
        {
            var outputModel = new UserSearchOutputModel();
            try
            {
                if (searchModel.Name.IsNullOrEmpty()
                    && searchModel.Surname.IsNullOrEmpty()
                    && searchModel.Email.IsNullOrEmpty()
                    && searchModel.UserName.IsNullOrEmpty())
                {
                    var allUserList = await _userRepository.GetAll();

                    foreach (var user in allUserList)
                    {
                        outputModel.OutputList.Add(new UserBaseModel
                        {
                            Id = user.Id,
                            UserName = user.UserName,
                            Email = user.Email,
                            Name = user.Name,
                            Surname = user.Surname,
                        });
                    }
                    outputModel.ItemCount = allUserList.Count();
                }
                else
                {
                    var filter = FilterBuilderForUserSearch(searchModel);
                    var userList = await _userRepository.GetByFilter(filter);

                    foreach (var user in userList)
                    {
                        outputModel.OutputList.Add(new UserBaseModel
                        {
                            Id = user.Id,
                            UserName = user.UserName,
                            Email = user.Email,
                            Name = user.Name,
                            Surname = user.Surname,
                        });
                    }
                    outputModel.ItemCount = userList.Count();
                }
                outputModel.Message = "Users Queried Sucessfully";
                outputModel.IsSuccess = true;

                return outputModel;
            }
            catch (Exception ex)
            {
                outputModel.Message = ex.Message;
                outputModel.IsSuccess = false;
                return outputModel;
            }
        }

        private static ExpressionStarter<User> FilterBuilderForUserSearch(UserSearchModel searchModel)
        {
            var predicate = PredicateBuilder.New<User>();

            if (!searchModel.UserName.IsNullOrEmpty())
            {
                predicate.And(a => a.UserName.Contains(searchModel.UserName));
            }

            if (!searchModel.Name.IsNullOrEmpty())
            {
                predicate.And(a => a.Name.Contains(searchModel.Name));
            }

            if (!searchModel.Email.IsNullOrEmpty())
            {
                predicate.And(a => a.Email.Contains(searchModel.Email));
            }

            if (!searchModel.Surname.IsNullOrEmpty())
            {
                predicate.And(a => a.Surname.Contains(searchModel.Surname));
            }

            return predicate;
        }
    }
}