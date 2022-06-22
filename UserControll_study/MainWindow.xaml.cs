using System.Windows;

namespace UserControll_study
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel mainViewModel;
        public MainWindow()
        {
            mainViewModel = new MainViewModel();
            InitializeComponent();
            this.DataContext = mainViewModel;
        }
    }
}
