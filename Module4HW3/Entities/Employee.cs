using System;

namespace Module4HW3.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HiredDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Title TiteleId { get; set; }
        public Office OfficeId { get; set; }
    }
}
