﻿using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public class DeptDTO
    {
            public int DeptCode { get; set; }
            public string DeptName { get; set; }
            public ICollection<EmployeeDTO> Employees { get; set; } 
        }

}

