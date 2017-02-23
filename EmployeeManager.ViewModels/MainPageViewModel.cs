using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace EmployeeManager.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;
        public DelegateCommand NavigationSectionListCommand { get; }
        public DelegateCommand DeepLinkByLiteralCommand { get; }
        public DelegateCommand DeepLinkByViewModelCommand { get; }

        public MainPageViewModel()
        {
            
        }
        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            //NavigationSectionListCommand = 
            //    new DelegateCommand(() => _navigationService.NavigateAsync<SectionListPageViewModel>());

            DeepLinkByLiteralCommand =
                new DelegateCommand(
                    () => _navigationService.NavigateAsync(
                        "/NavigationPage/MainPage/SectionListPage/SelectedSection?sectionId=5"));

            DeepLinkByViewModelCommand = new DelegateCommand(() =>
            {
                //// ReSharper disable once UseObjectOrCollectionInitializer
                //var sectionPageNavigation = new PageNavigation<SectionPageViewModel>();
                //sectionPageNavigation.Parameters[SectionPageViewModel.SectionIdKey] = 9;

                //_navigationService.NavigateAsync(
                //    new PageNavigation("NavigationPage"),
                //    new PageNavigation<MainPageViewModel>(),
                //    new PageNavigation<SectionListPageViewModel>(),
                //    sectionPageNavigation);
            });
        }
    }
}
