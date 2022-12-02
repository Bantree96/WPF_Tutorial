using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Focus
{
    public interface IReqeustFocus
    {
        event EventHandler<FocusRequestedEventArgs> FocusReqested;
    }

    public class FocusRequestedEventArgs : EventArgs
    {
        public string PropertyName { get; private set; }

        public FocusRequestedEventArgs(string propertyName)
        {
            PropertyName = propertyName;
        }

    }
}
