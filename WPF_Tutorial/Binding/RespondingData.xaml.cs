using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// RespondingData.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class RespondingData : Window
    {
        // 일반 List로 제작시 변경된게 관측 되지않는다.
        //private List<User> users = new List<User>();

        private ObservableCollection<User> users = new ObservableCollection<User>();

        public RespondingData()
        {
            InitializeComponent();

            users.Add(new User() { Name = "John Doe" });
            users.Add(new User() { Name = "Jane Doe" });

            lbUsers.ItemsSource = users;
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            users.Add(new User() { Name = "New user" });
        }

        private void btnChangeUser_Click(object sender, RoutedEventArgs e)
        {
            if(lbUsers.SelectedItem != null)
            {
                (lbUsers.SelectedItem as User).Name = "Random Name";
            }
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if(lbUsers.SelectedItem != null)
            {
                users.Remove(lbUsers.SelectedItem as User);
            }
        }
    }
    /*
    public class User : INotifyPropertyChanged
	{
		private string name;
		public string Name {
			get { return this.name; }
			set
			{
				if(this.name != value)
				{
					this.name = value;
					this.NotifyPropertyChanged("Name");
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void NotifyPropertyChanged(string propName)
		{
			if(this.PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
		}
	}
    */
    public class User
    {
        public string Name { get; set; }
    }
}
