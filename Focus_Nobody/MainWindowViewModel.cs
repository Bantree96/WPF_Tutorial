using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Focus_Nobody
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            // Invoke = UI스레드에 동기식으로 작업목록 추가
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _isUserNameFocus;
        public bool IsUserNameFocus { get => _isUserNameFocus; set { _isUserNameFocus = value; OnPropertyChanged(nameof(IsUserNameFocus)); } }
        public Command BtnClick { get; set; }
        public MainWindowViewModel()
        {
            BtnClick = new Command(OnBtnClick, CanExecute_func);
        }
        private bool CanExecute_func(object obj)
        {
            return true;
        }

        private void OnBtnClick(object obj)
        {
            IsUserNameFocus = true;
        }
    }
}
