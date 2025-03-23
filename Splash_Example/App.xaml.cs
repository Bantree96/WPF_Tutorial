using Splash_Example.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Splash_Example
{
	/// <summary>
	/// App.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class App : Application
	{
		private static string _splashWindowPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\splashwindow.bmp";
		private void Application_Startup(object sender, StartupEventArgs e)
		{
			MainWindowViewModel viewModel = new MainWindowViewModel();

			MainWindow mainWindow =	new MainWindow(viewModel);

			SplashScreen splashScreen = new SplashScreen(_splashWindowPath);
			splashScreen.Show(false);

			mainWindow.Show();
        }

    }
}
