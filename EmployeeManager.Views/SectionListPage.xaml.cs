using EmployeeManager.ViewModels;
using Xamarin.Forms;

namespace EmployeeManager.Views
{
    public partial class SectionListPage
    {
        public SectionListPage()
        {
            InitializeComponent();
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var section = e.Item as Section;
            if (section != null)
            {
                ((SectionListPageViewModel)BindingContext).OnSelectedSection(section);
            }
        }
    }
}
