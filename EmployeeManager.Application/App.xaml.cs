using System.Reflection;
using EmployeeManager.ViewModels;
using EmployeeManager.Views;
using NextGateForPrism;
using Prism.Mvvm;
using Prism.Unity;

namespace EmployeeManager.Application
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            ViewTypeToViewModelTypeResolver.AssignAssemblies<MainPage, MainPageViewModel>();
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(ViewTypeToViewModelTypeResolver.Resolve);
        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("MainPage?title=Hello%20from%20Xamarin.Forms");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
        }
    }
}
