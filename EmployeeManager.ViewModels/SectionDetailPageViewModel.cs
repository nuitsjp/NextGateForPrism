using EmployeeManager.Models.Usecases;
using NextGateForPrism;

namespace EmployeeManager.ViewModels
{
    [PageNavigation("SectionPage")]
    public class SectionDetailPageViewModel : SectionPageViewModel
    {
        public SectionDetailPageViewModel(IReferSections referSections) : base(referSections)
        {
        }
    }
}
