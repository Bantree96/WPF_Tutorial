using System.Windows.Controls;

namespace WPF_Tutorial.Usercontrol
{
    /// <summary>
    /// LimitText.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LimitText : UserControl
    {
        public LimitText()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public string Title { get; set; }
        public int MaxLength { get; set; }
    }
}
