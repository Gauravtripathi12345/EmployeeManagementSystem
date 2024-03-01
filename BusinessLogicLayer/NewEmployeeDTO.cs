﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class NewEmployeeDTO
    {
        public int EmpCode { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string EmpName { get; set; }
        public string Email { get; set; }
        public int? DeptCode { get; set; }
    }
}
