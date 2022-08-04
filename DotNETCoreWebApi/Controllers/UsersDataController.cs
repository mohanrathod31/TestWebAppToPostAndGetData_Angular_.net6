using DotNETCoreWebApi.Interfaces;
using DotNETCoreWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNETCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersDataController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersDataController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult Get()
        {
            var users =  _userService.GetUserList();
            return Ok(users);
        }

   
        [HttpPost]
        [Route("CreateUser")]
        public IActionResult Post([FromBody] UserModel user)
        {
            if (user is null)
            {
                throw new System.ArgumentNullException(nameof(user));
            }

            if (ModelState.IsValid)
            {
                _userService.AddUser(user);
                
            }

            return Ok(user);
        }
    }
}
