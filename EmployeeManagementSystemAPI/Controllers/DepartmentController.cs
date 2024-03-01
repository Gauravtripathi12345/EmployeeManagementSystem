using BusinessLogicLayer;
using EmployeeManagementSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeManagementSystemAPI.Controllers
{
    public class DepartmentController : ApiController
    {
        private readonly DepartmentManager departmentManager;

        public DepartmentController()
        {
            departmentManager = new DepartmentManager();
        }

        [HttpGet]
        [Route("api/departmentsdata")]
        public IHttpActionResult GetDepartments()
        {
            var departmentData = departmentManager.GetDepartmentData();
            if (departmentData == null || departmentData.Count == 0)
            {
                return NotFound();
            }

            return Ok(departmentData);
        }

        [HttpGet]
        [Route("api/department")]
        public IHttpActionResult GetDepartmentsWithEmployee()
        {
            List<DeptDTO> departments = departmentManager.GetDepartments();
            List<DeptModel> departmentModels = new List<DeptModel>();

            foreach (var department in departments)
            {
                DeptModel departmentModel = new DeptModel
                {
                    DeptCode = department.DeptCode,
                    DeptName = department.DeptName,
                    Employees = new List<EmpModel>()
                };

                foreach (var employee in department.Employees)
                {
                    departmentModel.Employees.Add(new EmpModel
                    {
                        EmpCode = employee.EmpCode,
                        DateOfBirth = employee.DateOfBirth,
                        EmpName = employee.EmpName,
                        Email = employee.Email
                    });
                }

                departmentModels.Add(departmentModel);
            }

            return Ok(departmentModels);
        }

        [HttpGet]
        [Route("api/department/{id}")]

        public IHttpActionResult GetDepartmentById(int id)
        {
            DepartmentDataDTO department = departmentManager.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }

            DepartmentDataModel departmentDataModel = new DepartmentDataModel
            {
                DeptCode = department.DeptCode,
                DeptName = department.DeptName
            };

            return Ok(departmentDataModel);
        }

        [HttpPost]
        [Route("api/department")]
        public IHttpActionResult PostDepartment(DepartmentDataModel departmentDataModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DepartmentDataDTO departmentDataDTO = new DepartmentDataDTO
            {
                DeptCode = departmentDataModel.DeptCode,
                DeptName = departmentDataModel.DeptName
            };

            bool success = departmentManager.AddDepartment(departmentDataDTO);
            if (!success)
            {
                return InternalServerError();
            }

            return Ok("Department added successfully");
        }

        [HttpPut]
        [Route("api/department/{id}")]
        public IHttpActionResult PutDepartment(int id, DepartmentDataModel departmentDataModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != departmentDataModel.DeptCode)
            {
                return BadRequest($"{id} not found in the database");
            }

            DepartmentDataDTO departmentDataDTO = new DepartmentDataDTO
            {
                DeptCode = departmentDataModel.DeptCode,
                DeptName = departmentDataModel.DeptName
            };

            bool success = departmentManager.UpdateDepartment(departmentDataDTO);
            if (!success)
            {
                return InternalServerError();
            }

            return Ok("Updated Department detail");
        }

        [HttpDelete]
        [Route("api/department/{id}")]
        public IHttpActionResult DeleteDepartment(int id)
        {
            bool success = departmentManager.DeleteDepartment(id);
            if (!success)
            {
                return BadRequest($"Deletion not possible for Department Id:{id}");
            }

            return Ok("Deleted the Department");
        }
    }
}
