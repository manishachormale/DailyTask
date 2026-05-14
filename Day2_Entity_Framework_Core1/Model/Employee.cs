namespace Day2_Entity_Framework_Core1.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public int DepartmentId {  get; set; }//foreign key
        public Department Department { get; set; } 
    }
}
