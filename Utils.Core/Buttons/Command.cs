using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Utils.Core.Buttons
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        // 실행 함수 로직을 저장
        Action<object> _execute;

        // 지금 실행 가능한지 판단하는 조건
        Func<object, bool> _canExecute;
        public Command(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        // 보통 UI에서 IsEnabled 속성에 영향을 줌
        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;
            return _canExecute(parameter);
        }

        // 커맨드를 실행 하는 부분
        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                _execute(parameter);
            }
        }

        // 보통 버튼 상태를 갱신할 때 사용
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
