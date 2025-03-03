using ComboBox_StaticType.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Core.Binding;

namespace ComboBox_StaticType.ViewModels
{
    public class MainWindowViewModel : NotifyBase
    {
		private MyEnum _user;
		public MyEnum User { get => _user; set => SetProperty(ref _user, value); }
		public MainWindowViewModel()
		{
				
		}
	}
}
