using Day2_Entity_Framework_Core1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Day2_Entity_Framework_Core1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly MyDbContext myDbContext;

        public EmployeeController(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }

        [HttpPost]
        public IActionResult EmployeeRegistration(EmployeeDTO employeeDTO)
        {
            var Department = myDbContext.Department.FirstOrDefault(d => d.Name == employeeDTO.DepartmentName);
            if (Department == null)
            {
                return BadRequest($"Department '{employeeDTO.DepartmentName}'not found");
            }
            var employee = new Employee
            {
                Name = employeeDTO.Name,
                Email = employeeDTO.Email,
                Phone = employeeDTO.Phone,
                City = employeeDTO.City,
                DepartmentId = Department.Id //set foreign key to department
            };
            myDbContext.Employees.Add(employee);
            myDbContext.SaveChanges();
            return Ok("employee registered");
        }

        [HttpGet]
        public IActionResult GetEmployee()
        {
            var employees = myDbContext.Employees.Include(e=>e.Department).ToList();
            var employeeResponses = employees.Select(e => new EmployeeResponseDTO
            {
                Name = e.Name,
                Email = e.Email,
                Phone= e.Phone,
                City = e.City,
                DepartmentName= e.Department.Name
            }).ToList();
            return Ok(employeeResponses);

            //return Ok(employees);
            //hello
            //hhdsj
        }

        
    }
}
