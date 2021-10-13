using GrTechTest.Business.Models;
using GrTechTest.Business.Repositories;
using GrTechTest.Business.Utils;
using System;
using System.Collections.Generic;

namespace GrTechTest.Business.Services
{
    public class CompanyService
    {
        CompanyRepository _companyRepository = new CompanyRepository();

        public ResponseMessage SaveCompany(Company company)
        {
            try
            {
                var companyExist = _companyRepository.GetCompanyById(company.Id);
                if (companyExist == null)
                {
                    if (company.Id == null) company.Id = Guid.NewGuid().ToString();
                    company.CreatedBy = company.UpdatedBy;
                    company.CreatedOn = DateTime.Now;
                    company.UpdatedOn = DateTime.Now;
                    company.IsDeleted = false;
                    var result = _companyRepository.InsertCompany(company);
                    if (result > 0)
                        return new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "Company has been saved successfully!" };
                    else
                        return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed saving Company!" };
                }
                else
                {
                    company.CreatedBy = companyExist.CreatedBy;
                    company.CreatedOn = companyExist.CreatedOn;
                    company.UpdatedOn = DateTime.Now;
                    company.IsDeleted = false;
                    var result = _companyRepository.UpdateCompany(company);
                    if (result > 0)
                        return new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "Company has been updated successfully!" };
                    else
                        return new ResponseMessage() { Success = false, Status = ResponseStatus.Success.ToString(), Message = "Failed saving Company!" };
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ResponseMessage DeleteCompany(string id, string updatedBy)
        {
            try
            {
                var company = _companyRepository.GetCompanyById(id);
                if (company != null)
                {
                    company.UpdatedBy = updatedBy;
                    company.UpdatedOn = DateTime.Now;
                    company.IsDeleted = true;
                    var result = _companyRepository.UpdateCompany(company);
                    if (result > 0)
                        return new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "Company has been deleted successfully!" };
                    else
                        return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed deleting Company!" };
                }
                else
                    return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed deleting Company!" };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ResponseMessage RestoreDeletedCompany(string id, string updatedBy)
        {
            try
            {
                var company = _companyRepository.GetDeletedCompanyById(id);
                if (company != null)
                {
                    company.UpdatedBy = updatedBy;
                    company.UpdatedOn = DateTime.Now;
                    company.IsDeleted = false;
                    var result = _companyRepository.UpdateCompany(company);
                    if (result > 0)
                        return new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "Company has been restored successfully!" };
                    else
                        return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed restoring deleted Company!" };
                }
                else
                    return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed restoring deleted Company!" };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ResponseMessage PermanentDeleteCompany(string id)
        {
            try
            {
                var company = _companyRepository.GetDeletedCompanyById(id);
                if (company != null)
                {
                    var result = _companyRepository.PermanentDeleteCompany(id);
                    if (result > 0)
                        return new ResponseMessage() { Success = true, Status = ResponseStatus.Success.ToString(), Message = "Company has been deleted permanently successfully!" };
                    else
                        return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed permanently deleting Company!" };
                }
                else
                    return new ResponseMessage() { Success = false, Status = ResponseStatus.Error.ToString(), Message = "Failed permanently deleting Company!" };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<Company> GetCompanies()
        {
            try
            {
                return _companyRepository.GetCompanies();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<Company> GetDeletedCompanies()
        {
            try
            {
                return _companyRepository.GetDeletedCompanies();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Company GetCompanyById(string id)
        {
            try
            {
                return _companyRepository.GetCompanyById(id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Company GetDeletedCompanyById(string id)
        {
            try
            {
                return _companyRepository.GetDeletedCompanyById(id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}