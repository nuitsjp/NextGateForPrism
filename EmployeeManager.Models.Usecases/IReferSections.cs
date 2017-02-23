using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace EmployeeManager.Models.Usecases
{
    public interface IReferSections : INotifyPropertyChanged
    {
        IEnumerable<Section> Sections { get; }

        SectionDetail SelectedSection { get; }

        Task Load();

        Task SelectSection(int sectionId);
    }
}