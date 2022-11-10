using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyValuePairBinding
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Binding
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                // View 
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        private List<KeyValuePair<int, string>> _items;
        private KeyValuePair<int, string> _item;


        public string Title { get; set; } = "TEST";
        public Dictionary<int, string> Dict { get; set; } = new Dictionary<int, string>();
        public List<KeyValuePair<int, string>> Items { get { return _items; } set { _items = value; OnPropertyChanged(nameof(Items)); } }

        public KeyValuePair<int, string> cam1 { get { return _item; } set { _item = value; OnPropertyChanged(nameof(cam1)); } }
        public KeyValuePair<int, string> cam2 { get { return _item; } set { _item = value; OnPropertyChanged(nameof(cam2)); } }

        public MainViewModel()
        {
            Dict.Add(1, "A");
            Dict.Add(2, "B");


            Items = Dict.ToList();

        }

    }
}
