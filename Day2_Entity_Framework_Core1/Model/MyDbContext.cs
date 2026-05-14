using Microsoft.EntityFrameworkCore;

namespace Day2_Entity_Framework_Core1.Model
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet <Department> Department { get; set; }
    }
}
