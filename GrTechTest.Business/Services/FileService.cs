using GrTechTest.Business.Models;
using GrTechTest.Business.Repositories;
using GrTechTest.Business.Utils;
using System;
using System.Collections.Generic;

namespace GrTechTest.Business.Services
{
    public class FileService
    {
        FileRepository _fileRepository = new FileRepository();

        public ResponseMessage SaveFile(File file)
        {
            try
            {
                var fileExist = _fileRepository.GetFileById(file.Id);
                if (fileExist == null)
                {
                    if (file.Id == null) file.Id = Guid.NewGuid().ToString();
                    file.CreatedBy = file.UpdatedBy;
                    file.CreatedOn = DateTime.Now;
                    file.UpdatedOn = DateTime.Now;
                    file.IsDeleted = false;
                    var result = _fileRepository.InsertFile(file);
                    if (result > 0)
                        return new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "File has been saved successfully!" };
                    else
                        return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed saving File!" };
                }
                else
                {
                    file.CreatedBy = fileExist.CreatedBy;
                    file.CreatedOn = fileExist.CreatedOn;
                    file.UpdatedOn = DateTime.Now;
                    file.IsDeleted = false;
                    var result = _fileRepository.UpdateFile(file);
                    if (result > 0)
                        return new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "File has been updated successfully!" };
                    else
                        return new ResponseMessage() { Success = false, Status = ResponseStatus.Success.ToString(), Message = "Failed saving File!" };
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ResponseMessage DeleteFile(string id, string updatedBy)
        {
            try
            {
                var file = _fileRepository.GetFileById(id);
                if (file != null)
                {
                    file.UpdatedBy = updatedBy;
                    file.UpdatedOn = DateTime.Now;
                    file.IsDeleted = true;
                    var result = _fileRepository.UpdateFile(file);
                    if (result > 0)
                        return new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "File has been deleted successfully!" };
                    else
                        return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed deleting File!" };
                }
                else
                    return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed deleting File!" };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ResponseMessage RestoreDeletedFile(string id, string updatedBy)
        {
            try
            {
                var file = _fileRepository.GetDeletedFileById(id);
                if (file != null)
                {
                    file.UpdatedBy = updatedBy;
                    file.UpdatedOn = DateTime.Now;
                    file.IsDeleted = false;
                    var result = _fileRepository.UpdateFile(file);
                    if (result > 0)
                        return new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "File has been restored successfully!" };
                    else
                        return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed restoring deleted File!" };
                }
                else
                    return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed restoring deleted File!" };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ResponseMessage PermanentDeleteFile(string id)
        {
            try
            {
                var file = _fileRepository.GetDeletedFileById(id);
                if (file != null)
                {
                    var result = _fileRepository.PermanentDeleteFile(id);
                    if (result > 0)
                        return new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "File has been deleted permanently successfully!" };
                    else
                        return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed permanently deleting File!" };
                }
                else
                    return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed permanently deleting File!" };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<File> GetFiles()
        {
            try
            {
                return _fileRepository.GetFiles();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<File> GetDeletedFiles()
        {
            try
            {
                return _fileRepository.GetDeletedFiles();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public File GetFileById(string id)
        {
            try
            {
                return _fileRepository.GetFileById(id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public File GetDeletedFileById(string id)
        {
            try
            {
                return _fileRepository.GetDeletedFileById(id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}