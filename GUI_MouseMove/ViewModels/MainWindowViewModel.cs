using GUI_MouseMove.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUI_MouseMove.ViewModels
{
	public class MainWindowViewModel : INotifyPropertyChanged
	{
		private double _rectangleLeft;
		private double _rectangleTop;
		private bool _isDragging;
		private Point _clickPosition;

		public double RectangleLeft { get => _rectangleLeft; set => SetProperty(ref _rectangleLeft, value); }
		public double RectangleTop { get => _rectangleTop; set => SetProperty(ref _rectangleTop, value); }
		public string Title { get; set; } = "Hello";

		public ICommand MouseDownCommand { get; }
		public ICommand MouseUpCommand { get; }
		public ICommand MouseMoveCommand { get; }
		public MainWindowViewModel()
		{
			// 초기 위치 설정
			RectangleLeft = 100;
			RectangleTop = 100;

			// 커맨드 초기화
			MouseDownCommand = new RelayCommand(OnMouseDown);
			MouseUpCommand = new RelayCommand(OnMouseUp);
			MouseMoveCommand = new RelayCommand(OnMouseMove);
		}

		private void OnMouseMove(object parameter)
		{
			if (_isDragging && parameter is MouseEventArgs e)
			{
				var currentPosition = e.GetPosition(null);

				// 위치 업데이트
				RectangleLeft += currentPosition.X - _clickPosition.X;
				RectangleTop += currentPosition.Y - _clickPosition.Y;

				// 클릭 위치 업데이트
				_clickPosition = currentPosition;
			}
		}

		private void OnMouseUp(object obj)
		{
			_isDragging = false;
		}

		private void OnMouseDown(object parameter)
		{
			if (parameter is MouseEventArgs e)
			{
				_isDragging = true;
				_clickPosition = e.GetPosition(null);
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected virtual void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
		{
			if (!Equals(field, value))
			{
				field = value;
				OnPropertyChanged(propertyName);
			}
		}
	}
}
