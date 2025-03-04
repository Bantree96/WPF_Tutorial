using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DotDraw
{
	/// <summary>
	/// MainWindow.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class MainWindow : Window
	{
		private MainViewModel _mainViewModel = new MainViewModel();

		public MainWindow()
		{
			InitializeComponent();

			DataContext = _mainViewModel;
		}

		private void DrawingCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			var canvas = sender as Canvas;
			var position = e.GetPosition(canvas);

			// Canvas의 실제 사이즈 가져오기
			double actualWidth = canvas.ActualWidth;
			double actualHeight = canvas.ActualHeight;

			// 이미지 원본 사이즈와의 비율 계산
			double scaleX = 4112 / actualWidth;
			double scaleY = 3008 / actualHeight;

			// 원본 이미지 상의 좌표 계산
			double imageX = position.X * scaleX;
			double imageY = position.Y * scaleY;

			// ViewModel의 커맨드에 원본 이미지 좌표 전달
			var viewModel = (MainViewModel)DataContext;
			viewModel.AddPointCommand.Execute(new Point(imageX, imageY));
		}
	}
}
