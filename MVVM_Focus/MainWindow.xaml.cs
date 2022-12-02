using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVM_Focus
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IReqeustFocus focus = (IReqeustFocus)DataContext;
            focus.FocusReqested += OnFocusRequested;
        }

        private void OnFocusRequested(object sender, FocusRequestedEventArgs e)
        {
            var viewModel = (MainWindowViewModel)DataContext;
            switch (e.PropertyName)
            {
                case nameof(viewModel.ID):
                    IDTextBox.Focus();
                    break;
            }
        }
    }
}
