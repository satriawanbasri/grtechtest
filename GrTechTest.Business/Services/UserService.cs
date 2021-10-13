using GrTechTest.Business.Models;
using GrTechTest.Business.Repositories;
using GrTechTest.Business.Utils;
using System;
using System.Collections.Generic;

namespace GrTechTest.Business.Services
{
    public class UserService
    {
        UserRepository _userRepository = new UserRepository();

        public ResponseMessage SaveUser(User user)
        {
            try
            {
                var userExist = _userRepository.GetUserById(user.Id);
                if (userExist == null)
                {
                    if (user.Id == null) user.Id = Guid.NewGuid().ToString();
                    user.CreatedBy = user.UpdatedBy;
                    user.CreatedOn = DateTime.Now;
                    user.UpdatedOn = DateTime.Now;
                    user.IsDeleted = false;
                    var result = _userRepository.InsertUser(user);
                    if (result > 0)
                        return new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "User has been saved successfully!" };
                    else
                        return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed saving User!" };
                }
                else
                {
                    user.CreatedBy = userExist.CreatedBy;
                    user.CreatedOn = userExist.CreatedOn;
                    user.UpdatedOn = DateTime.Now;
                    user.IsDeleted = false;
                    var result = _userRepository.UpdateUser(user);
                    if (result > 0)
                        return new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "User has been updated successfully!" };
                    else
                        return new ResponseMessage() { Success = false, Status = ResponseStatus.Success.ToString(), Message = "Failed saving User!" };
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ResponseMessage DeleteUser(string id, string updatedBy)
        {
            try
            {
                var user = _userRepository.GetUserById(id);
                if (user != null)
                {
                    user.UpdatedBy = updatedBy;
                    user.UpdatedOn = DateTime.Now;
                    user.IsDeleted = true;
                    var result = _userRepository.UpdateUser(user);
                    if (result > 0)
                        return new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "User has been deleted successfully!" };
                    else
                        return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed deleting User!" };
                }
                else
                    return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed deleting User!" };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ResponseMessage RestoreDeletedUser(string id, string updatedBy)
        {
            try
            {
                var user = _userRepository.GetDeletedUserById(id);
                if (user != null)
                {
                    user.UpdatedBy = updatedBy;
                    user.UpdatedOn = DateTime.Now;
                    user.IsDeleted = false;
                    var result = _userRepository.UpdateUser(user);
                    if (result > 0)
                        return new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "User has been restored successfully!" };
                    else
                        return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed restoring deleted User!" };
                }
                else
                    return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed restoring deleted User!" };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ResponseMessage PermanentDeleteUser(string id)
        {
            try
            {
                var user = _userRepository.GetDeletedUserById(id);
                if (user != null)
                {
                    var result = _userRepository.PermanentDeleteUser(id);
                    if (result > 0)
                        return new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "User has been deleted permanently successfully!" };
                    else
                        return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed permanently deleting User!" };
                }
                else
                    return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed permanently deleting User!" };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<User> GetUsers()
        {
            try
            {
                return _userRepository.GetUsers();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<User> GetDeletedUsers()
        {
            try
            {
                return _userRepository.GetDeletedUsers();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public User GetUserById(string id)
        {
            try
            {
                return _userRepository.GetUserById(id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public User GetDeletedUserById(string id)
        {
            try
            {
                return _userRepository.GetDeletedUserById(id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public User GetUserByEmail(string email)
        {
            try
            {
                return _userRepository.GetUserByEmail(email);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}