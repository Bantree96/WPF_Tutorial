using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Utils.Core.Binding;
using Utils.Core.Buttons;

namespace TapWindow.ViewModels
{
    public class MainWindowViewModel : NotifyBase
    {
        public string Title { get; set; } = "TapWindow";
        public ICommand DialogCommand => new Command(OnShowDialog);

        private void OnShowDialog(object obj)
        {
            MessageBox.Show("Hello, World!");
        }

        public MainWindowViewModel()
        {
            
        }
    }
}
