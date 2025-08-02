using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Utilities;
namespace Task2.Utilities
{
	internal class BoolToIconConverter : IValueConverter
	{
		public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			if (value != null)
			{
				bool isTrue = (bool)value;
				return isTrue ? FontHelper.CLOSED_EYE_ICON : FontHelper.OPEN_EYE_ICON;  // Return the appropriate icon based on the boolean value
			}
			return FontHelper.CLOSED_EYE_ICON;
		}

		public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
