using System.Windows;
using System.Windows.Navigation;

namespace WPF_Tutorial.Control
{
    /// <summary>
    /// TextBlock.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TextBlock : Window
    {
        public TextBlock()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            // 하이퍼 링크는 WPF page와 page 사이를 이동하는데에도 사용된다.
            // 그럴 때는 이런 Process클래스 사용은 필요없다.
            System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);
        }
    }
}
