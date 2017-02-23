using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models.Services.Local
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> _employees = new List<Employee>();
        private readonly List<Section> _sections = new List<Section>();

        public EmployeeService()
        {
            for (int i = 0; i < 20; i++)
            {
                _sections.Add(new Section { Id = i, Name = $"Section{i}" });
                for (int j = 0; j < 10; j++)
                {
                    _employees.Add(new Employee { Id = i * 10 + j, Name = $"Employee{i}-{j}", SectionId = i});
                }
            }
        }
        public Task<IEnumerable<Employee>> GetEmployees()
        {
            return Task.FromResult<IEnumerable<Employee>>(new List<Employee>(_employees));
        }

        public Task<IEnumerable<Section>> GetSectionsAsynk()
        {
            return Task.FromResult<IEnumerable<Section>>(new List<Section>(_sections));
        }

        public Task<SectionDetail> GetSectionDetailAsync(int sectionId)
        {
            var section = _sections.Single(x => x.Id == sectionId);
            var sectionDetail = new SectionDetail
            {
                Id = sectionId,
                Name = section.Name,
                Employees = _employees.Where(x => x.SectionId == sectionId)
            };
            return Task.FromResult(sectionDetail);
        }
    }
}