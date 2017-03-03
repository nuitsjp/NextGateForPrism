using System.Linq;
using Prism.Navigation;

namespace NextGateForPrism
{
    public class PageNavigation
    {
        public string Name { get; }
        public NavigationParameters Parameters { get; } = new NavigationParameters();
        public bool? UseModalNavigation { get; set; }
        public bool Animated { get; set; } = true;

        public PageNavigation(string name)
        {
            Name = name;
        }
        public override string ToString() => Parameters.Any() ? Name + Parameters : Name;
    }

    public class PageNavigation<TViewModel> : PageNavigation where TViewModel : class 
    {
        //public PageNavigation() : base(PageNavigationTypeResolver.ResolveForViewType<TViewModel>().Name)
        public PageNavigation() : base(PageNavigationNameResolver.Resolve<TViewModel>())
        {
        }
    }
}
