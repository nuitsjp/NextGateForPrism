using Prism.Mvvm;
using EmployeeManager.Models.Usecases;
using Prism.Navigation;

namespace EmployeeManager.ViewModels
{
    //[PageNavigation("SelectedSection", "SectionPage")]
    public class SectionPageViewModel : BindableBase, INavigationAware
    {
        public const string SectionIdKey = "sectionId";

        private readonly IReferSections _referSections;
        private SectionDetail _sectionDetail;

        public SectionDetail SectionDetail
        {
            get { return _sectionDetail; }
            set { SetProperty(ref _sectionDetail, value); }
        }
        public SectionPageViewModel(IReferSections referSections)
        {
            _referSections = referSections;
            _referSections.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "SelectedSection")
                {
                    SectionDetail = _referSections.SelectedSection;
                }
            };
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey(SectionIdKey))
            {
                var sectionId = parameters[SectionIdKey].ToString();
                await _referSections.SelectSection(int.Parse(sectionId));
            }
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}
