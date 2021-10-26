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
using System.Windows.Shapes;

namespace WPF_Tutorial.Binding
{
    /// <summary>
    /// UpdateSourceTrigger.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UpdateSourceTrigger : Window
    {
        public UpdateSourceTrigger()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void btnUpdateSource_Click(object sender, RoutedEventArgs e)
        {
            // UpdateSource를 사용하기 위한 코드
            BindingExpression binding = txtWindowTitle.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
        }
    }
}
