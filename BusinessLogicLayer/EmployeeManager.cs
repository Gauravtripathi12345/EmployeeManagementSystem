using System;
using System.Collections.Generic;
using System.Linq;
using Data_Access_Layer;

namespace BusinessLogicLayer
{
    public class EmployeeManager
    {
        private readonly EmployeeManagementDatabaseEntities dbContext;

        public EmployeeManager()
        {
            dbContext = new EmployeeManagementDatabaseEntities();
        }

        public bool AddEmployee(NewEmployeeDTO newEmployeeDTO)
        {
            try
            {
                Employee employee = new Employee
                {
                    EmpCode = newEmployeeDTO.EmpCode,
                    DateOfBirth = newEmployeeDTO.DateOfBirth,
                    EmpName = newEmployeeDTO.EmpName,
                    Email = newEmployeeDTO.Email,
                    DeptCode= newEmployeeDTO.DeptCode
                };

                dbContext.Employees.Add(employee);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<EmployeeDTO> GetEmployees()
        {
            List<EmployeeDTO> employeeDTOList = dbContext.Employees.Select(emp => new EmployeeDTO
            {
                EmpCode = emp.EmpCode,
                DateOfBirth = emp.DateOfBirth,
                EmpName = emp.EmpName,
                Email = emp.Email
            }).ToList();

            return employeeDTOList;
        }

        public EmployeeDTO GetEmployeeById(int empCode)
        {
            Employee employee = dbContext.Employees.Find(empCode);
            if (employee == null)
                return null;

            EmployeeDTO employeeDTO = new EmployeeDTO
            {
                EmpCode = employee.EmpCode,
                DateOfBirth = employee.DateOfBirth,
                EmpName = employee.EmpName,
                Email = employee.Email
            };
            return employeeDTO;
        }

        public bool UpdateEmployee(NewEmployeeDTO newEmployeeDTO)
        {
            try
            {
                Employee employee = dbContext.Employees.Find(newEmployeeDTO.EmpCode);
                if (employee == null)
                    return false;

                employee.DateOfBirth = newEmployeeDTO.DateOfBirth;
                employee.EmpName = newEmployeeDTO.EmpName;
                employee.Email = newEmployeeDTO.Email;
                employee.DeptCode = newEmployeeDTO.DeptCode;

                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteEmployee(int empCode)
        {
            try
            {
                Employee employee = dbContext.Employees.Find(empCode);
                if (employee == null)
                    return false;

                dbContext.Employees.Remove(employee);
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
