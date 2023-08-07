namespace RelApp.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid DepartmentId { get; set; }

        //virtual
        public  Department Department { get; set; }

    }
}
