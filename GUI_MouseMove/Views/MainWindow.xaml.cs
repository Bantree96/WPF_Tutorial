using GUI_MouseMove.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace GUI_MouseMove
{
	/// <summary>
	/// MainWindow.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class MainWindow : Window
	{
		private bool isDragging = false;
		private Point clickPosition;

		private bool isResizing = false;
		private Point initialMousePosition;
		private double initialWidth, initialHeight, initialLeft, initialTop;
		private string resizeDirection;

		public MainWindow(MainWindowViewModel model)
		{
			InitializeComponent();
			DataContext = model;
		}

		private void Rectangle_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			// 드래그 시작
			isDragging = true;
			var rectangle = sender as Rectangle;
			clickPosition = e.GetPosition(rectangle);

			// 캔버스로 포커스 설정
			rectangle.CaptureMouse();
		}

		private void Resize_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
		{
			if (isResizing)
			{
				var currentPosition = e.GetPosition(canvas);
				double deltaX = currentPosition.X - initialMousePosition.X;
				double deltaY = currentPosition.Y - initialMousePosition.Y;

				switch (resizeDirection)
				{
					case "TopLeft":
						Canvas.SetLeft(resizableRectangle, initialLeft + deltaX);
						Canvas.SetTop(resizableRectangle, initialTop + deltaY);
						resizableRectangle.Width = initialWidth - deltaX;
						resizableRectangle.Height = initialHeight - deltaY;

						break;

					case "TopRight":
						Canvas.SetTop(resizableRectangle, initialTop + deltaY);
						resizableRectangle.Width = initialWidth + deltaX;
						resizableRectangle.Height = initialHeight - deltaY;
						break;

					case "BottomLeft":
						Canvas.SetLeft(resizableRectangle, initialLeft + deltaX);
						resizableRectangle.Width = initialWidth - deltaX;
						resizableRectangle.Height = initialHeight + deltaY;
						break;

					case "BottomRight":
						resizableRectangle.Width = initialWidth + deltaX;
						resizableRectangle.Height = initialHeight + deltaY;
						break;
				}

				
			}
		}


		private void Resize_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			isResizing = false;
			(sender as Rectangle).ReleaseMouseCapture();
		}

		private void Rectangle_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
		{
			if (isDragging)
			{
				var rectangle = sender as Rectangle;
				var currentPosition = e.GetPosition(canvas);

				// 새 위치 계산
				double newLeft = currentPosition.X - clickPosition.X;
				double newTop = currentPosition.Y - clickPosition.Y;

				// 캔버스의 위치 업데이트
				Canvas.SetLeft(rectangle, newLeft);
				Canvas.SetTop(rectangle, newTop);

				Canvas.SetLeft(resize_leftTop, newLeft);
				Canvas.SetTop(resize_leftTop, newTop);
			}
		}

		private void Rectangle_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			// 드래그 종료
			isDragging = false;
			var rectangle = sender as Rectangle;

			// 마우스 캡처 해제
			rectangle.ReleaseMouseCapture();
		}

		private void Resize_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			isResizing = true;
			initialMousePosition = e.GetPosition(canvas);

			// 현재 Rectangle의 초기 위치 및 크기 저장
			initialWidth = resizableRectangle.Width;
			initialHeight = resizableRectangle.Height;
			initialLeft = Canvas.GetLeft(resizableRectangle);
			initialTop = Canvas.GetTop(resizableRectangle);

			// 현재 핸들의 위치 (Tag) 정보 저장
			resizeDirection = (sender as Rectangle)?.Tag.ToString();

			(sender as Rectangle).CaptureMouse();
		}
	}
}
