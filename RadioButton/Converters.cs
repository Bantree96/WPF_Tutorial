using System;
using System.Globalization;
using System.Windows.Data;

namespace RadioButton
{
    /// <summary>
    /// 라디오 버튼 - 검사 타입
    /// </summary>
    public class RadioBoolToInspectionTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.Equals(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.Equals(true) == true ? parameter : Binding.DoNothing;
        }
    }
}
