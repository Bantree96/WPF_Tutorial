using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_Focus
{
    public class Command : ICommand
    {
        // 버튼 사용하기 위한 무명함수 생성
        Action<object> _executeMethod;
        Func<object, bool> _canexecuteMethod;

        // 생성자
        public Command(Action<object> executeMethod, Func<object, bool> canexecuteMethod)
        {
            this._executeMethod = executeMethod;
            this._canexecuteMethod = canexecuteMethod;
        }

        public event EventHandler CanExecuteChanged;

        // Excute하기전 필요한 조건을 검사하는 함수
        public bool CanExecute(object parameter)
        {
            // 특별히 조건이 없기 때문에 true
            return true;
        }

        // 바인딩된 커맨드가 실제로 실행할 함수
        public void Execute(object parameter)
        {
            // 무명함수 들어온대로 그대로 실행
            _executeMethod(parameter);
        }
    }
}
