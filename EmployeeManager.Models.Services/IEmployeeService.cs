using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManager.Models.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();

        Task<IEnumerable<Section>> GetSectionsAsynk();

        Task<SectionDetail> GetSectionDetailAsync(int sectionId);
    }
}