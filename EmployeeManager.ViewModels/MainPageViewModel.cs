using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using NextGateForPrism;

namespace EmployeeManager.ViewModels
{
    [PageNavigation("m")]
    public class MainPageViewModel : BindableBase
    {
        public DelegateCommand NavigationSectionListCommand { get; }
        public DelegateCommand DeepLinkByLiteralCommand { get; }
        public DelegateCommand DeepLinkByViewModelCommand { get; }

        public MainPageViewModel(INavigationService navigationService)
        {
            NavigationSectionListCommand =
                new DelegateCommand(() => navigationService.NavigateAsync<SectionListPageViewModel>());

            //DeepLinkByLiteralCommand =
            //    new DelegateCommand(
            //        () => navigationService.NavigateAsync(
            //            "/NavigationPage/MainPage/SectionListPage/SelectedSection?sectionId=5"));
            DeepLinkByLiteralCommand =
                new DelegateCommand(
                    () => navigationService.NavigateAsync(
                        "/NavigationPage/m/SectionListPage/SectionPage?sectionId=5"));

            DeepLinkByViewModelCommand = new DelegateCommand(() =>
            {
                var sectionPageNavigation = new PageNavigation<SectionDetailPageViewModel>();
                sectionPageNavigation.Parameters.Add(SectionPageViewModel.SectionIdKey, 9);

                navigationService.NavigateAsync(
                    new PageNavigation("NavigationPage"),
                    new PageNavigation<MainPageViewModel>(),
                    new PageNavigation<SectionListPageViewModel>(),
                    sectionPageNavigation);
            });
        }
    }
}
