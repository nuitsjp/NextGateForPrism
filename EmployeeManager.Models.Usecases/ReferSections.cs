using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManager.Models.Services;
using Prism.Mvvm;

namespace EmployeeManager.Models.Usecases
{
    public class ReferSections : BindableBase, IReferSections
    {
        private readonly IEmployeeService _employeeService;

        private IEnumerable<Section> _sections;
        public IEnumerable<Section> Sections
        {
            get { return _sections; }
            private set { SetProperty(ref _sections, value); }
        }

        private SectionDetail _selectedSection;
        public SectionDetail SelectedSection
        {
            get { return _selectedSection; }
            set { SetProperty(ref _selectedSection, value); }
        }

        public ReferSections(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task Load()
        {
            Sections = await _employeeService.GetSectionsAsynk();
        }

        public async Task SelectSection(int sectionId)
        {
            SelectedSection = await _employeeService.GetSectionDetailAsync(sectionId);
        }
    }
}