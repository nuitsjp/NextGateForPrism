using EmployeeManager.Models.Services;
using EmployeeManager.Models.Services.Local;
using EmployeeManager.Models.Usecases;
using EmployeeManager.ViewModels;
using EmployeeManager.Views;
using Microsoft.Practices.Unity;
using NextGateForPrism;
using NextGateForPrism.Unity;
using Prism.Mvvm;
using Prism.Unity;
using Xamarin.Forms;

namespace EmployeeManager.Application
{
    public partial class App
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            PageNavigationTypeResolver.AssignAssemblies<MainPage, MainPageViewModel>();
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(PageNavigationTypeResolver.ResolveForViewModelType);
        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync(new PageNavigation("NavigationPage"), new PageNavigation<MainPageViewModel>());
        }

        protected override void RegisterTypes()
        {
            Container.RegisterType<IReferSections, ReferSections>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IEmployeeService, EmployeeService>(new ContainerControlledLifetimeManager());

            Container.RegisterTypeForNavigation<NavigationPage>();
            //Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigationFromViewModel<MainPageViewModel>();
            Container.RegisterTypeForNavigation<SectionListPage>();
            Container.RegisterTypeForNavigationFromViewModel<SectionPage, SectionDetailPageViewModel>();
        }
    }
}
