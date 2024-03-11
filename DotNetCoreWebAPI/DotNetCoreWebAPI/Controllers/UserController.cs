using DotNetCoreWebAPI.Models;
using DotNetCoreWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;

        public UserController(IUserService UserService)
        {
            _UserService = UserService;
        }

        /// <summary>
        /// Get all Users
        /// </summary>
        /// <returns>A list of Users</returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetUsers()
        {
            try
            {
                var Users = _UserService.GetUsersList();
                if (Users == null)
                    return NotFound();
                return Ok(Users);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Get User details by id
        /// </summary>
        /// <param name="id">The id of the User</param>
        /// <returns>The User details</returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var User = _UserService.GetUserDetailsById(id);
                if (User == null)
                    return NotFound();
                return Ok(User);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Save User
        /// </summary>
        /// <param name="UserModel">The User model to save</param>
        /// <returns>A response indicating the result of the operation</returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveUser(UserSaveDto UserModel)
        {
            try
            {
                var model = _UserService.SaveUser(UserModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="id">The id of the User to delete</param>
        /// <returns>A response indicating the result of the operation</returns>
        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var model = _UserService.DeleteUser(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
