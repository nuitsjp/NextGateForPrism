using Prism.Mvvm;
using System.Collections.Generic;
using EmployeeManager.Models.Usecases;
using Prism.Navigation;

namespace EmployeeManager.ViewModels
{
    public class SectionListPageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly IReferSections _referSections;
        private IEnumerable<Section> _sections;

        public IEnumerable<Section> Sections
        {
            get { return _sections; }
            private set { SetProperty(ref _sections, value); }
        }
        public SectionListPageViewModel(IReferSections referSections, INavigationService navigationService)
        {
            _referSections = referSections;
            _navigationService = navigationService;
            _referSections.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "Sections")
                {
                    Sections = _referSections.Sections;
                }
            };
        }

        public void OnSelectedSection(Section section)
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var navigationParameter = new NavigationParameters();
            navigationParameter[SectionPageViewModel.SectionIdKey] = section.Id;

            //_navigationService.NavigateAsync<SectionPageViewModel>(navigationParameter);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            await _referSections.Load();
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}
