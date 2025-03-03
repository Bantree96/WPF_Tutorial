using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace ComboBox_StaticType.Converter
{
	public class EnumToItemSource_Converter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is Type enumType && enumType.IsEnum)
			{
				return Enum.GetValues(enumType).Cast<Enum>().ToList();
			}
			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
