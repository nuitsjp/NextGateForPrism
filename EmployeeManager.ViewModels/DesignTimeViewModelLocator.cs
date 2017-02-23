namespace EmployeeManager.ViewModels
{
    public static class DesignTimeViewModelLocator
    {
        public static MainPageViewModel MainPageViewModel => default(MainPageViewModel);
        public static SectionPageViewModel SectionPageViewModel => default(SectionPageViewModel);
        public static SectionListPageViewModel SectionListPageViewModel => default(SectionListPageViewModel);
    }
}