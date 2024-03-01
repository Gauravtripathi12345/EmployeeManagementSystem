using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer;

namespace BusinessLogicLayer
{
    public class DepartmentManager
    {
        private readonly EmployeeManagementDatabaseEntities dbContext;

        public DepartmentManager()
        {
            dbContext = new EmployeeManagementDatabaseEntities();
        }

        public List<DepartmentDataDTO> GetDepartmentData()
        {
            List<DepartmentDataDTO> departmentData = dbContext.Departments
                .Select(dept => new DepartmentDataDTO
                {
                    DeptCode = dept.DeptCode,
                    DeptName = dept.DeptName
                })
                .ToList();

            return departmentData;
        }
        public bool AddDepartment(DepartmentDataDTO departmentDataDTO)
        {
            try
            {
                Department department = new Department
                {
                    DeptCode = departmentDataDTO.DeptCode,
                    DeptName = departmentDataDTO.DeptName
                };

                dbContext.Departments.Add(department);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<DeptDTO> GetDepartments()
        {
            List<DeptDTO> deptDTOList = dbContext.Departments.Select(dept => new DeptDTO
            {
                DeptCode = dept.DeptCode,
                DeptName = dept.DeptName,
                Employees = dept.Employees.Select(e => new EmployeeDTO
                {
                    EmpCode = e.EmpCode,
                    DateOfBirth = e.DateOfBirth,
                    EmpName = e.EmpName,
                    Email = e.Email
                }).ToList()
            }).ToList();

            return deptDTOList;
        }

        public DepartmentDataDTO GetDepartmentById(int deptCode)
        {
            Department department = dbContext.Departments.Find(deptCode);
            if (department == null)
                return null;

            DepartmentDataDTO departmentDataDTO = new DepartmentDataDTO
            {
                DeptCode = department.DeptCode,
                DeptName = department.DeptName
            };
            return departmentDataDTO;
        }

        public bool UpdateDepartment(DepartmentDataDTO departmentDataDTO)
        {
            try
            {
                Department department = dbContext.Departments.Find(departmentDataDTO.DeptCode);
                if (department == null)
                    return false;

                department.DeptName = departmentDataDTO.DeptName;
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteDepartment(int deptCode)
        {
            try
            {
                Department department = dbContext.Departments.Find(deptCode);
                if (department == null)
                    return false;

                dbContext.Departments.Remove(department);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
