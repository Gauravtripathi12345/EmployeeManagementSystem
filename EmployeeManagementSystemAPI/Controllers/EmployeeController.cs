using BusinessLogicLayer;
using EmployeeManagementSystemAPI.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace EmployeeManagementSystemAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly EmployeeManager employeeManager;

        public EmployeeController()
        {
            employeeManager = new EmployeeManager();
        }

        [HttpPost]
        [Route("api/employee")]
        public IHttpActionResult PostEmployee(NewEmployeeModel newEmpModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            NewEmployeeDTO newEmployeeDTO = new NewEmployeeDTO
            {
                EmpCode = newEmpModel.EmpCode,
                DateOfBirth = newEmpModel.DateOfBirth,
                EmpName = newEmpModel.EmpName,
                Email = newEmpModel.Email,
                DeptCode = newEmpModel.DeptCode
            };
            bool success = employeeManager.AddEmployee(newEmployeeDTO);
            if (!success)
            {
                return BadRequest("Error");
            }
            return Ok("Employee added successfully");
        }

        [HttpGet]
        [Route("api/employee")]
        public IHttpActionResult GetAllEmployees()
        {
            List<EmployeeDTO> employees = employeeManager.GetEmployees();
            List<EmpModel> employeeModels = new List<EmpModel>();

            foreach (var employee in employees)
            {
                EmpModel empModel = new EmpModel
                {
                    EmpCode = employee.EmpCode,
                    DateOfBirth = employee.DateOfBirth,
                    EmpName = employee.EmpName,
                    Email = employee.Email
                };
                employeeModels.Add(empModel);
            }
            return Ok(employeeModels);
        }

        [HttpGet]
        [Route ("api/employee/{id}")]
        public IHttpActionResult GetEmployeeById(int id)
        {
            EmployeeDTO employee = employeeManager.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            EmpModel empModel = new EmpModel
            {
                EmpCode = employee.EmpCode,
                DateOfBirth = employee.DateOfBirth,
                EmpName = employee.EmpName,
                Email = employee.Email
            };

            return Ok(empModel);
        }

        [HttpPut]
        [Route("api/employee/{id}")]
        public IHttpActionResult PutEmployeeById(int id, NewEmployeeModel newEmpModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != newEmpModel.EmpCode)
            {
                return BadRequest();
            }
            NewEmployeeDTO newEmployeeDTO = new NewEmployeeDTO
            {
                EmpCode = newEmpModel.EmpCode,
                DateOfBirth = newEmpModel.DateOfBirth,
                EmpName = newEmpModel.EmpName,
                Email = newEmpModel.Email,
                DeptCode = newEmpModel.DeptCode
            };
            bool success = employeeManager.UpdateEmployee(newEmployeeDTO);
            if (!success)
            {
                return BadRequest("Error");
            }

            return Ok("Updated Employee details");
        }

        [HttpDelete]
        [Route("api/employee/{id}")]
        public IHttpActionResult DeleteEmployee(int id)
        {
            bool success = employeeManager.DeleteEmployee(id);
            if (!success)
            {
                return BadRequest($"Unable to delete the Employee details with Id:{id}");
            }
            return Ok("Deleted the account");
        }
    }
}
