using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NextGateForPrism
{
    public class PageNavigationNameResolver
    {
        private static readonly Dictionary<Type, string> NavigationNames = new Dictionary<Type, string>();
        public static string Resolve<TViewModel>() where TViewModel : class
        {
            string name;
            if (!NavigationNames.TryGetValue(typeof(TViewModel), out name))
            {
                name = typeof(TViewModel).GetTypeInfo().GetCustomAttribute<PageNavigationAttribute>()?.Name;
                if (string.IsNullOrEmpty(name))
                {
                    name = PageNavigationTypeResolver.ResolveForViewType<TViewModel>()?.Name;
                }
                NavigationNames[typeof(TViewModel)] = name;
            }
            return name;
        }
    }
}
