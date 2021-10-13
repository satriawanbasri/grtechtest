using GrTechTest.Business.Models;
using GrTechTest.Business.Repositories;
using GrTechTest.Business.Utils;
using System;
using System.Collections.Generic;

namespace GrTechTest.Business.Services
{
    public class UserRoleService
    {
        UserRoleRepository _userRoleRepository = new UserRoleRepository();

        public ResponseMessage SaveUserRole(UserRole userRole)
        {
            try
            {
                var userRoleExist = _userRoleRepository.GetUserRoleById(userRole.Id);
                if (userRoleExist == null)
                {
                    if (userRole.Id == null) userRole.Id = Guid.NewGuid().ToString();
                    userRole.CreatedBy = userRole.UpdatedBy;
                    userRole.CreatedOn = DateTime.Now;
                    userRole.UpdatedOn = DateTime.Now;
                    userRole.IsDeleted = false;
                    userRole.User = null;
                    userRole.Role = null;
                    var result = _userRoleRepository.InsertUserRole(userRole);
                    if (result > 0)
                        return new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "UserRole has been saved successfully!" };
                    else
                        return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed saving UserRole!" };
                }
                else
                {
                    userRole.CreatedBy = userRoleExist.CreatedBy;
                    userRole.CreatedOn = userRoleExist.CreatedOn;
                    userRole.UpdatedOn = DateTime.Now;
                    userRole.IsDeleted = false;
                    userRole.User = null;
                    userRole.Role = null;
                    var result = _userRoleRepository.UpdateUserRole(userRole);
                    if (result > 0)
                        return new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "UserRole has been updated successfully!" };
                    else
                        return new ResponseMessage() { Success = false, Status = ResponseStatus.Success.ToString(), Message = "Failed saving UserRole!" };
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ResponseMessage DeleteUserRole(string id, string updatedBy)
        {
            try
            {
                var userRole = _userRoleRepository.GetUserRoleById(id);
                if (userRole != null)
                {
                    userRole.UpdatedBy = updatedBy;
                    userRole.UpdatedOn = DateTime.Now;
                    userRole.IsDeleted = true;
                    var result = _userRoleRepository.UpdateUserRole(userRole);
                    if (result > 0)
                        return new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "UserRole has been deleted successfully!" };
                    else
                        return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed deleting UserRole!" };
                }
                else
                    return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed deleting UserRole!" };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ResponseMessage RestoreDeletedUserRole(string id, string updatedBy)
        {
            try
            {
                var userRole = _userRoleRepository.GetDeletedUserRoleById(id);
                if (userRole != null)
                {
                    userRole.UpdatedBy = updatedBy;
                    userRole.UpdatedOn = DateTime.Now;
                    userRole.IsDeleted = false;
                    var result = _userRoleRepository.UpdateUserRole(userRole);
                    if (result > 0)
                        return new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "UserRole has been restored successfully!" };
                    else
                        return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed restoring deleted UserRole!" };
                }
                else
                    return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed restoring deleted UserRole!" };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ResponseMessage PermanentDeleteUserRole(string id)
        {
            try
            {
                var userRole = _userRoleRepository.GetDeletedUserRoleById(id);
                if (userRole != null)
                {
                    var result = _userRoleRepository.PermanentDeleteUserRole(id);
                    if (result > 0)
                        return new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "UserRole has been deleted permanently successfully!" };
                    else
                        return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed permanently deleting UserRole!" };
                }
                else
                    return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed permanently deleting UserRole!" };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<UserRole> GetUserRoles()
        {
            try
            {
                return _userRoleRepository.GetUserRoles();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<UserRole> GetDeletedUserRoles()
        {
            try
            {
                return _userRoleRepository.GetDeletedUserRoles();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public UserRole GetUserRoleById(string id)
        {
            try
            {
                return _userRoleRepository.GetUserRoleById(id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public UserRole GetDeletedUserRoleById(string id)
        {
            try
            {
                return _userRoleRepository.GetDeletedUserRoleById(id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<UserRole> GetUserRolesByUserId(string userId)
        {
            try
            {
                return _userRoleRepository.GetUserRolesByUserId(userId);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}