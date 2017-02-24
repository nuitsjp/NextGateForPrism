using System;
using System.Collections.Generic;
using System.Reflection;

namespace NextGateForPrism
{
    public static class PageNavigationTypeResolver
    {
        private static readonly Dictionary<Assembly, Assembly> AssembliesForResolvingViewModelType = new Dictionary<Assembly, Assembly>();
        private static readonly Dictionary<Assembly, Assembly> AssembliesForResolvingViewType = new Dictionary<Assembly, Assembly>();

        public static void AssignAssemblies<TView, TViewModel>()
        {
            var viewAssembly = typeof(TView).GetTypeInfo().Assembly;
            var viewModelAssembly = typeof(TViewModel).GetTypeInfo().Assembly;
            AssembliesForResolvingViewModelType[viewAssembly] = viewModelAssembly;
            AssembliesForResolvingViewType[viewModelAssembly] = viewAssembly;
        }

        private static Assembly ResolveViewModelAssembly(Assembly viewAssembly)
        {
            Assembly result;
            if (!AssembliesForResolvingViewModelType.TryGetValue(viewAssembly, out result))
            {
                result = viewAssembly;
                AssembliesForResolvingViewModelType[viewAssembly] = result;
            }
            return result;
        }

        public static Type ResolveForViewModelType(Type viewType)
        {
            if (viewType == null) throw new ArgumentNullException(nameof(viewType));

            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var suffix = viewName.EndsWith("View") ? "Model" : "ViewModel";
            var assembly = ResolveViewModelAssembly(viewType.GetTypeInfo().Assembly);
            return assembly.GetType($"{viewName}{suffix}");
        }

        private static Assembly ResolveViewAssembly(Assembly viewModelAssembly)
        {
            Assembly result;
            if (!AssembliesForResolvingViewType.TryGetValue(viewModelAssembly, out result))
            {
                result = viewModelAssembly;
                AssembliesForResolvingViewModelType[viewModelAssembly] = result;
            }
            return result;
        }

        public static Type ResolveForViewType<TViewModel>() where TViewModel : class
        {
            var viewModelName = typeof(TViewModel).FullName.Replace(".ViewModels.", ".Views.");
            var suffixLength = viewModelName.EndsWith("PageViewModel") ? "ViewModel".Length : "Model".Length;
            var assembly = ResolveViewAssembly(typeof(TViewModel).GetTypeInfo().Assembly);
            return assembly.GetType(viewModelName.Substring(0, viewModelName.Length - suffixLength));
        }

        public static void Clear()
        {
            AssembliesForResolvingViewModelType.Clear();
            AssembliesForResolvingViewType.Clear();
        }
    }
}
