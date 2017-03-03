using System.Reflection;
using Microsoft.Practices.Unity;
using Prism.Mvvm;
using Prism.Unity;

namespace NextGateForPrism.Unity
{
    public static class UnityContainerExtensions
    {
        public static IUnityContainer RegisterTypeForNavigationFromViewModel<TViewModel>(this IUnityContainer container) where TViewModel : class
        {
            var viewType = PageNavigationTypeResolver.ResolveForViewType<TViewModel>();
            var name = PageNavigationNameResolver.Resolve<TViewModel>();
            return container.RegisterTypeForNavigation(viewType, name);
        }
    }
}
