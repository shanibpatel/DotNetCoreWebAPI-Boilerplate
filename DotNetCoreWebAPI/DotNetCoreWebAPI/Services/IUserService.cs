using DotNetCoreWebAPI.Data;
using DotNetCoreWebAPI.Models;
using DotNetCoreWebAPI.ViewModels;

namespace DotNetCoreWebAPI.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Get list of all users
        /// </summary>
        /// <returns>List of users</returns>
        List<Users> GetUsersList();

        /// <summary>
        /// Get user details by user id
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <returns>The user details</returns>
        Users GetUserDetailsById(int userId);

        /// <summary>
        /// Add or edit a user
        /// </summary>
        /// <param name="user">The user model to be saved</param>
        /// <returns>A response indicating the result of the operation</returns>
        ResponseModel SaveUser(UserSaveDto user);

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="userId">The id of the user to be deleted</param>
        /// <returns>A response indicating the result of the operation</returns>
        ResponseModel DeleteUser(int userId);
    }
}
