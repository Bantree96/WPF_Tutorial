using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace Custom_ItemControl
{
    class MainWindowViewModel : INotifyPropertyChanged
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

        private ObservableCollection<Item> _items;
        public ObservableCollection<Item> Items { get { return _items; } set { _items = value; OnPropertyChanged(nameof(Items)); } }

        public MainWindowViewModel()
        {
            Items = new ObservableCollection<Item>();

            Item a = new Item();
            Items.Add(a);
            Items.Add(a);
            Items.Add(a);
        }
    }

    public class Item 
    {

        public BitmapImage Image { get; set; }
        public int Score { get; set; } = 0;
        public string Text { get; set; } = "abc";
    }
}
