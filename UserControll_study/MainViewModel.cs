using System.ComponentModel;

namespace Page_study
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Binding
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Field
        private string _pagePath;

        #endregion
        #region Prop
        public string PagePath { get { return _pagePath; } set { _pagePath = value; OnPropertyChanged(nameof(PagePath)); } }
        #endregion


        #region Command
        public Command btn1_click { get; set; }
        public Command btn2_click { get; set; }

        private bool CanExecute_func(object obj)
        {
            return true;
        }
        private void Execute_func1(object obj)
        {
            PagePath = "/Pages/MainPage.xaml";
        }

        private void Execute_func2(object obj)
        {
            PagePath = "/Pages/SubPage.xaml";
        }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            PagePath =  "/Pages/MainPage.xaml";

            btn1_click = new Command(Execute_func1, CanExecute_func);
            btn2_click = new Command(Execute_func2, CanExecute_func);
        }
        #endregion

    }
}
