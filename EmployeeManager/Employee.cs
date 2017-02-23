using Prism.Mvvm;

namespace EmployeeManager
{
    public class Employee : BindableBase
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value);  }
        }

        private int _sectionId;
        public int SectionId
        {
            get { return _sectionId; }
            set { SetProperty(ref _sectionId, value); }
        }
    }
}
