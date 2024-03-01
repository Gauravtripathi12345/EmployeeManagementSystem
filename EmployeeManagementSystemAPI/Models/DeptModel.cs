using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLayer;

namespace EmployeeManagementSystemAPI.Models
{
    public class DeptModel
    {
        public int DeptCode { get; set; }
        public string DeptName { get; set; }
        public ICollection<EmpModel> Employees { get; set; } // Assuming EmpModel represents employee data in the API layer
    }
}