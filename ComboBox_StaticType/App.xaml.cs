using ComboBox_StaticType.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ComboBox_StaticType
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
	{
		private void Application_Startup(object sender, StartupEventArgs e)
		{
			MainWindowViewModel viewModel = new MainWindowViewModel();

			MainWindow window = new MainWindow(viewModel);
			window.Show();
		}
	}
}
