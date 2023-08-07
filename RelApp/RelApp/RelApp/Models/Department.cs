﻿namespace RelApp.Models
{
    public class Department
    {
        //Guid
        public Guid Id { get; set; }

        public string Name { get; set; }

        //ICollection List
        public  List<Employee>? Employees { get; set; }
        //public int MyProperty { get; set; }

    }
}
