﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLayer;

namespace EmployeeManagementSystemAPI.Models
{
    public class EmpModel
    {
        public int EmpCode { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string EmpName { get; set; }
        public string Email { get; set; }
        //public int? DeptCode { get; set; } 
        //public DeptModel Department { get; set; } 
    }
}