using System;
using System.Windows.Input;

namespace DotDraw
{
	public class RelayCommand : ICommand
	{
		private readonly Action<object> _execute;
		private readonly Func<object, bool> _canExecute;

		public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
		{
			_execute = execute;
			_canExecute = canExecute;

		}
		public event EventHandler CanExecuteChanged
		{
			add => CommandManager.RequerySuggested += value;
			remove => CommandManager.RequerySuggested -= value;
		}

		public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);


		public void Execute(object parameter) => _execute(parameter);

	}

	public class RelayCommand<T> : ICommand
	{
		private readonly Action<T> _execute;
		private readonly Predicate<T> _canExecute;

		// 생성자 (canExecute가 필요하지 않은 경우 null로 설정 가능)
		public RelayCommand(Action<T> execute, Predicate<T> canExecute = null)
		{
			_execute = execute ?? throw new ArgumentNullException(nameof(execute));
			_canExecute = canExecute;
		}

		// ICommand 인터페이스 구현
		public event EventHandler CanExecuteChanged
		{
			add => CommandManager.RequerySuggested += value;
			remove => CommandManager.RequerySuggested -= value;
		}

		public bool CanExecute(object parameter)
		{
			return _canExecute == null || _canExecute((T)parameter);
		}

		public void Execute(object parameter)
		{
			_execute((T)parameter);
		}
	}
}
