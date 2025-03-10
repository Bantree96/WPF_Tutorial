﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ComboBox_Binding.Types;

namespace ComboBox_Binding
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Binding
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                // View 
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Field
        private string _txt;
        #endregion

        #region Property
        public string Txt { get { return _txt; } set { _txt = value; OnPropertyChanged(nameof(Txt)); } }
        public Array MyEnumArray {  get => Enum.GetValues(typeof(MyEnum)); }
        #endregion

        #region Constructor
        public MainViewModel()
        {
        }
        #endregion
    }
}
