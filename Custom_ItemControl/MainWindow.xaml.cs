using System.Windows;

namespace Custom_ItemControl
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            InitializeComponent();
            this.DataContext = mainWindowViewModel;
        }
    }
}
