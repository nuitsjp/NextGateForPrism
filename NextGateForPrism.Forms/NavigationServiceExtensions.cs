using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Navigation;

namespace NextGateForPrism
{
    public static class NavigationServiceExtensions
    {
        public static Task NavigateAsync<TViewModel>(
            this INavigationService navigationService, 
            NavigationParameters parameters = null, 
            bool? useModalNavigation = null, 
            bool animated = true) where TViewModel : class 
        {
            //var viewType = PageNavigationTypeResolver.ResolveForViewType<TViewModel>();
            //return navigationService.NavigateAsync(viewType.Name, parameters, useModalNavigation, animated);
            var name = PageNavigationNameResolver.Resolve<TViewModel>();
            return navigationService.NavigateAsync(name, parameters, useModalNavigation, animated);
        }

        public static Task NavigateAsync(
            this INavigationService navigationService, 
            params PageNavigation[] pageNavigations)
        {
            if(!pageNavigations.Any()) throw new ArgumentException("pageNavigation is empty.");

            const string delimiter = "/";
            var latest = pageNavigations.Last();

            return navigationService.NavigateAsync(
                delimiter + string.Join<PageNavigation>(delimiter, pageNavigations), 
                null, 
                latest.UseModalNavigation, 
                latest.Animated);
        }
    }
}
