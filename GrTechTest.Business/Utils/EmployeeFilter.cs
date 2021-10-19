using System;

namespace GrTechTest.Business.Utils
{
    public class EmployeeFilter
    {
        public DateTime? DateAddedFrom { get; set; }
        public DateTime? DateAddedTo { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
    }
}