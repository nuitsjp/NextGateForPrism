using System;
using System.Collections.Generic;
using System.Reflection;

namespace NextGateForPrism
{
    public static class ViewTypeToViewModelTypeResolver
    {
        private static readonly Dictionary<Assembly, Assembly> Assemblies = new Dictionary<Assembly, Assembly>();

        public static void MappingAssemblies(Assembly viewAssembly, Assembly viewModelAssembly)
        {
            if (viewAssembly == null) throw new ArgumentNullException(nameof(viewAssembly));
            if (viewModelAssembly == null) throw new ArgumentNullException(nameof(viewModelAssembly));

            Assemblies[viewAssembly] = viewModelAssembly;
        }

        private static Assembly ResolveViewModelAssembly(Assembly viewAssembly)
        {
            Assembly result;
            if (!Assemblies.TryGetValue(viewAssembly, out result))
            {
                result = viewAssembly;
                Assemblies[viewAssembly] = result;
            }
            return result;
        }

        public static Type Resolve(Type viewType)
        {
            if (viewType == null) throw new ArgumentNullException(nameof(viewType));

            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var suffix = viewName.EndsWith("View") ? "Model" : "ViewModel";
            var assembly = ResolveViewModelAssembly(viewType.GetTypeInfo().Assembly);
            return assembly.GetType($"{viewName}{suffix}");
        }
    }
}
