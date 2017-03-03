using Microsoft.Practices.Unity;
using Prism.Mvvm;
using Prism.Unity;

namespace NextGateForPrism.Unity.Forms
{
    public static class UnityContainerExtensions
    {
        public static IUnityContainer RegisterTypeForViewModelNavigation<TViewModel>(this IUnityContainer container) where TViewModel : class
        {
            var viewType = PageNavigationTypeResolver.ResolveForViewType<TViewModel>();
            ViewModelLocationProvider.Register(viewType.ToString(), typeof(TViewModel));
            return container.RegisterTypeForNavigation(viewType, viewType.Name);
        }
    }
}
