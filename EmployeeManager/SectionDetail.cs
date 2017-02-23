using System.Collections.Generic;

namespace EmployeeManager
{
    public class SectionDetail : Section
    {
        public IEnumerable<Employee> Employees { get; set; }
    }
}