using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Focus
{
    class MainWindowViewModel : INotifyPropertyChanged, IReqeustFocus
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<FocusRequestedEventArgs> FocusReqested;

        public void OnPropertyChanged(string propertyName)
        {
            // Invoke = UI스레드에 동기식으로 작업목록 추가
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OnFocusReqeusted(string propertyName)
        {
            FocusReqested?.Invoke(this, new FocusRequestedEventArgs(propertyName));
        }

        private string _id;
        public string ID { get => _id; set { _id = value; OnPropertyChanged(nameof(ID)); } }

        public Command BtnClick { get; set; }
        public MainWindowViewModel()
        {
            BtnClick = new Command(OnBtnClick, CanExecute_func);
        }

        private void OnBtnClick(object obj)
        {
            OnFocusReqeusted(nameof(ID));
        }

        private bool CanExecute_func(object obj)
        {
            return true;
        }


    }
}
