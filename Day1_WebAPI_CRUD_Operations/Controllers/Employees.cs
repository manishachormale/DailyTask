using Day1_WebAPI_CRUD_Operations.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day1_WebAPI_CRUD_Operations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Employees : ControllerBase
    {
        static List<Employee> employees = new List<Employee>()
        {
            new Employee{ Id = 1, FirstName = "Manisha", LastName = "Chormale",Department = "IT" },
            new Employee{ Id = 2, FirstName = "Poonam", LastName = "Kadam",Department = "Computer" },
            new Employee{ Id = 3, FirstName = "Shivraj", LastName = "Swami",Department = "Testing" },
            new Employee{ Id = 4, FirstName = "Pallavi", LastName = "Gavade",Department = "CSE" }

        };
        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(employees);
        }

        //get employee by Id
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = employees.FirstOrDefault(x => x.Id == id);

            if (employee == null)
            {
                return NotFound("Employee Not Found");
            }

            return Ok(employee);
        }


        //POST METHOD
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            employees.Add(employee);

            return Ok(employee);
        }


        //PUT Method
        //
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee employee)
        {
            var emp = employees.Where(x => x.Id == id).FirstOrDefault();

            emp.FirstName = employee.FirstName;
            emp.LastName = employee.LastName;
            emp.Department = employee.Department;

            return Ok(emp);
        }

        //Remove employee
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var emp = employees.Find(x => x.Id == id);

            employees.Remove(emp);

            return Ok("Employee Deleted");
        }

        //patch method
        [HttpPatch("{id}")]
        public IActionResult PatchEmployee(int id, Employee employee)
        {
            var emp = employees.Find(x => x.Id == id);

            if (emp == null)
            {
                return NotFound();
            }

            // Update only one field
            emp.Department = employee.Department;

            return Ok(emp);
        }

        

        










    }
}
