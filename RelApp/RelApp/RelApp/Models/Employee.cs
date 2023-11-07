namespace RelApp.Models
{
    public class Employee
    {
        //int
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }

        //virtual
        public  Department Department { get; set; }

    }
}
