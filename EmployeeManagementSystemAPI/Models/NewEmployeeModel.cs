using System;

namespace EmployeeManagementSystemAPI.Models
{
    public class NewEmployeeModel
    {
        public int EmpCode { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string EmpName { get; set; }
        public string Email { get; set; }
        public int? DeptCode { get; set; }
    }
}