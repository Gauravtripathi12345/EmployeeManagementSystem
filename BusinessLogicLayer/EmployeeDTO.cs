using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer;

namespace BusinessLogicLayer
{
    public class EmployeeDTO
    {
        public int EmpCode { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string EmpName { get; set; }
        public string Email { get; set; }
       // public int? DeptCode { get; set; } // Assuming DeptCode is required for representing department association
       // public DeptDTO Department { get; set; } // Assuming DepartmentDTO is defined in the Business Logic Layer
    }
}
