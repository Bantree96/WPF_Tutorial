using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace RadioButton
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Fields
        public enum INSPECTION_TYPE
        {
            Complete,
            Final
        }

        public static INSPECTION_TYPE _inspectionType;
        #endregion

        #region Properties
        public INSPECTION_TYPE InspectionType
        {
            get { return _inspectionType; }
            set
            {
                _inspectionType = value;
                OnPropertyChanged(nameof(InspectionType));
            }
        }
        #endregion

        #region Event
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Binding Method
        public void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            _inspectionType = INSPECTION_TYPE.Complete;
        }
        #endregion
    }
}
