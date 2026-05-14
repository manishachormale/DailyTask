using Day2_Entity_Framework_Core1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day2_Entity_Framework_Core1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly MyDbContext myDbContext;
        public DepartmentController(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }

        [HttpPost]
        public IActionResult AddDepartment(DepartmentDTO departmentDTO)
        {
            //var existingDepartment = myDbContext.Department.FirstOrDefault(d => d.Name == departmentDTO.Name);
            ////var existingDepartment = myDbContext.Departments.FirstOrDefault(d => d.Name == departmentDTO.Name);
            //if (existingDepartment != null)
            //{
            //    return BadRequest($"Department{departmentDTO.Name} already exist");
            //}
            var department = new Department
            {
                Name = departmentDTO.Name
            };
            myDbContext.Department.Add(department);
            myDbContext.SaveChanges();
            return Ok("department added successfully");
        }
    }
}
