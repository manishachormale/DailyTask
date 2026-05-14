namespace Day2_Entity_Framework_Core1.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  List<Employee> Employees { get; set; }
    }
}
