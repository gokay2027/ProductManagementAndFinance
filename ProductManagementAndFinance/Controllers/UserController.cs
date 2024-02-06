using Microsoft.AspNetCore.Mvc;
using ProductManagementAndFinanceApi.Application.Commands.Abstract;
using ProductManagementAndFinanceApi.Application.Queries.Abstract;

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


    }
}