namespace MVC4.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly DateOfJoining { get; set; }
        public double Salary { get; set; }
        public string Department{ get; set; }
    }
}
