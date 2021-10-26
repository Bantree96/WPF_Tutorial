using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WPF_Tutorial.Conversion
{
    /// <summary>
    /// Conversion.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Conversion : Window
    {
        public Conversion()
        {
            InitializeComponent();
        }
    }

    public class YesNoToBooleanConverter : IValueConverter
    {
        // 문자열을 매개변수로 입력받은 다음 대체값 이 bool => false, true로 변환된다고 가정
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch(value.ToString().ToLower())
            {
                case "yes":
                case "oui":
                    return true;

                case "no":
                case "non":
                    return false;
            }
            return false;
        }

        // Convert와 반대로 작동한다. bool값을 받으면 string => Yes, No로 변환된다고 가정
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is bool)
            {
                if ((bool)value == true)
                    return "yes";
                else
                    return "no";
            }
            return "no";
        }
    }
}
