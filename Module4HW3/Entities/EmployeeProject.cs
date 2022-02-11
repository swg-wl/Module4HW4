using System;

namespace Module4HW3.Entities
{
    public class EmployeeProject
    {
        public int EmployeeProjectId { get; set; }
        public decimal Rate { get; set; }
        public DateTime StartedDate { get; set; }
        public Employee EmployeeId { get; set; }
        public Project ProjectId { get; set; }
    }
}
