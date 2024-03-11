using AutoMapper;
using DotNetCoreWebAPI.Data;
using DotNetCoreWebAPI.Models;
using DotNetCoreWebAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreWebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly WebAPIDBContext _context;
        private readonly IMapper _mapper;

        public UserService(WebAPIDBContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        /// <summary>
        /// Get list of all Users
        /// </summary>
        /// <returns>List of Users</returns>
        public List<Users> GetUsersList()
        {
            List<Users> Users;
            try
            {
                Users = _context.Set<Users>()
                    .Include(u => u.Clients)
                    .Where(c => c.IsActive == true)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return Users;
        }

        /// <summary>
        /// Get User details by User id
        /// </summary>
        /// <param name="UserId">The id of the User</param>
        /// <returns>The User details</returns>
        public Users GetUserDetailsById(int UserId)
        {
            Users User;
            try
            {
                User = _context.Find<Users>(UserId);
            }
            catch (Exception)
            {
                throw;
            }
            return User;
        }

        /// <summary>
        /// Add or update a User
        /// </summary>
        /// <param name="UserModel">The User model to be saved</param>
        /// <returns>A response indicating the result of the operation</returns>
        public ResponseModel SaveUser(UserSaveDto userSaveDto)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Users existingUser = GetUserDetailsById(userSaveDto.UserId);
                if (existingUser != null)
                {
                    // Update existing User
                    //existingUser.ClientId = userSaveDto.ClientId;
                    //existingUser.UserName = userSaveDto.UserName;
                    //existingUser.Password = userSaveDto.Password;
                    //existingUser.Notes = userSaveDto.Notes;
                    //existingUser.IsActive = userSaveDto.IsActive;
                    //existingUser.CreatedBy = userSaveDto.CreatedBy;
                    //existingUser.CreatedWhen = userSaveDto.CreatedWhen;
                    //existingUser.TouchedBy = userSaveDto.TouchedBy;
                    //existingUser.TouchedWhen = userSaveDto.TouchedWhen;

                    // Update existing User
                    _mapper.Map(userSaveDto, existingUser);

                    _context.Update(existingUser);
                    model.Message = "User updated successfully.";
                }
                else
                {
                    // Add new User
                    var user = _mapper.Map<Users>(userSaveDto);
                    _context.Update<Users>(user);
                    model.Message = "User added successfully.";
                }

                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Message = "Error: " + ex.Message;
            }
            return model;
        }

        /// <summary>
        /// Delete a User
        /// </summary>
        /// <param name="UserId">The id of the User to be deleted</param>
        /// <returns>A response indicating the result of the operation</returns>

        ///Method to Delete the User
        //public ResponseModel DeleteUser(int UserId)
        //{
        //    ResponseModel model = new ResponseModel();
        //    try
        //    {
        //        Users UserToDelete = GetUserDetailsById(UserId);
        //        if (UserToDelete != null)
        //        {
        //            _context.Remove(UserToDelete);
        //            _context.SaveChanges();
        //            model.IsSuccess = true;
        //            model.Message = "User deleted successfully.";
        //        }
        //        else
        //        {
        //            model.IsSuccess = false;
        //            model.Message = "User not found.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        model.IsSuccess = false;
        //        model.Message = "Error: " + ex.Message;
        //    }
        //    return model;
        //}

        public ResponseModel DeleteUser(int UserId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Users UserToUpdate = GetUserDetailsById(UserId);
                if (UserToUpdate != null)
                {
                    // Instead of removing the User, update IsActive flag to false
                    UserToUpdate.IsActive = false;
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Message = "User deactivated successfully.";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Message = "User not found.";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Message = "Error: " + ex.Message;
            }
            return model;
        }

    }
}
