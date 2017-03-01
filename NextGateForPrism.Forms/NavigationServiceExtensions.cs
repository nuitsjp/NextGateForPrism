using System.Threading.Tasks;
using Prism.Navigation;

namespace NextGateForPrism
{
    public static class NavigationServiceExtensions
    {
        public static Task NavigateAsync<TViewModel>(this INavigationService navigationService, NavigationParameters parameters = null, bool? useModalNavigation = null, bool animated = true) where TViewModel : class 
        {
            var name = PageNavigationTypeResolver.ResolveForViewType<TViewModel>();
            return navigationService.NavigateAsync(name.Name, parameters, useModalNavigation, animated);
        }
    }
}
