using GrTechTest.Business.Models;
using GrTechTest.Business.Repositories;
using GrTechTest.Business.Utils;
using System;
using System.Collections.Generic;

namespace GrTechTest.Business.Services
{
    public class RoleService
    {
        RoleRepository _roleRepository = new RoleRepository();

        public ResponseMessage SaveRole(Role role)
        {
            try
            {
                var roleExist = _roleRepository.GetRoleById(role.Id);
                if (roleExist == null)
                {
                    if (role.Id == null) role.Id = Guid.NewGuid().ToString();
                    role.CreatedBy = role.UpdatedBy;
                    role.CreatedOn = DateTime.Now;
                    role.UpdatedOn = DateTime.Now;
                    role.IsDeleted = false;
                    var result = _roleRepository.InsertRole(role);
                    if (result > 0)
                        return new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "Role has been saved successfully!" };
                    else
                        return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed saving Role!" };
                }
                else
                {
                    role.CreatedBy = roleExist.CreatedBy;
                    role.CreatedOn = roleExist.CreatedOn;
                    role.UpdatedOn = DateTime.Now;
                    role.IsDeleted = false;
                    var result = _roleRepository.UpdateRole(role);
                    if (result > 0)
                        return new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "Role has been updated successfully!" };
                    else
                        return new ResponseMessage() { Success = false, Status = ResponseStatus.Success.ToString(), Message = "Failed saving Role!" };
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ResponseMessage DeleteRole(string id, string updatedBy)
        {
            try
            {
                var role = _roleRepository.GetRoleById(id);
                if (role != null)
                {
                    role.UpdatedBy = updatedBy;
                    role.UpdatedOn = DateTime.Now;
                    role.IsDeleted = true;
                    var result = _roleRepository.UpdateRole(role);
                    if (result > 0)
                        return new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "Role has been deleted successfully!" };
                    else
                        return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed deleting Role!" };
                }
                else
                    return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed deleting Role!" };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ResponseMessage RestoreDeletedRole(string id, string updatedBy)
        {
            try
            {
                var role = _roleRepository.GetDeletedRoleById(id);
                if (role != null)
                {
                    role.UpdatedBy = updatedBy;
                    role.UpdatedOn = DateTime.Now;
                    role.IsDeleted = false;
                    var result = _roleRepository.UpdateRole(role);
                    if (result > 0)
                        return new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "Role has been restored successfully!" };
                    else
                        return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed restoring deleted Role!" };
                }
                else
                    return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed restoring deleted Role!" };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ResponseMessage PermanentDeleteRole(string id)
        {
            try
            {
                var role = _roleRepository.GetDeletedRoleById(id);
                if (role != null)
                {
                    var result = _roleRepository.PermanentDeleteRole(id);
                    if (result > 0)
                        return new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "Role has been deleted permanently successfully!" };
                    else
                        return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed permanently deleting Role!" };
                }
                else
                    return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed permanently deleting Role!" };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<Role> GetRoles()
        {
            try
            {
                return _roleRepository.GetRoles();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<Role> GetDeletedRoles()
        {
            try
            {
                return _roleRepository.GetDeletedRoles();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Role GetRoleById(string id)
        {
            try
            {
                return _roleRepository.GetRoleById(id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Role GetDeletedRoleById(string id)
        {
            try
            {
                return _roleRepository.GetDeletedRoleById(id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}