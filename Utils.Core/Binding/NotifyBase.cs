using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Utils.Core.Binding
{
	public class NotifyBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
		{
			if(!Equals(field, value))
			{
				field = value;
				OnPropertyChanged(propertyName);
			}
		}
	}
}
