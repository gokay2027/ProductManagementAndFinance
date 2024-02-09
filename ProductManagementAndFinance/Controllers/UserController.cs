using Microsoft.AspNetCore.Mvc;
using ProductManagementAndFinanceApi.Application.Commands.Abstract;
using ProductManagementAndFinanceApi.Application.Queries.Abstract;
using ProductManagementAndFinanceApi.Models.Command.User;
using ProductManagementAndFinanceApi.Models.Query.User;

namespace ProductManagementAndFinanceApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserCommandBusiness _userCommandBusiness;
        private readonly IUserQuery _userQuery;

        public UserController(IUserCommandBusiness userCommandBusiness, IUserQuery userQuery)
        {
            _userCommandBusiness = userCommandBusiness;
            _userQuery = userQuery;
        }

        [HttpGet]
        public async Task<UserLoginOutputModel> LoginUser([FromQuery] UserLoginModel loginModel)
        {
            return await _userQuery.Login(loginModel);
        }

        [HttpGet]
        public async Task<UserSearchOutputModel> SearchUser([FromQuery] UserSearchModel searchModel)
        {
            return await _userQuery.SearchUser(searchModel);
        }

        [HttpPost]
        public async Task<UserAddCommandOutputModel> AddUser([FromBody] UserAddInputModel model)
        {
            return await _userCommandBusiness.AddUser(model);
        }

        [HttpDelete]
        public async Task<UserDeleteCommandOutputModel> DeleteUser([FromBody] UserDeleteInputModel model)
        {
            return await _userCommandBusiness.DeleteUser(model);
        }

        [HttpPut]
        public async Task<UserUpdateCommandOutputModel> UpdateUser([FromBody] UserUpdateInputModel model)
        {
            return await _userCommandBusiness.UpdateUser(model);
        }

        [HttpPut]
        public async Task<UserChangePasswordCommandOutputModel> ChangePassword([FromBody] UserChangePasswordInputModel model)
        {
            return await _userCommandBusiness.ChangePassword(model);
        }
    }
}