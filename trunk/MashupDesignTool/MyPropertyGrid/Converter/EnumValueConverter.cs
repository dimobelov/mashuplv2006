﻿using System;
using System.Globalization;
using System.Windows.Data;
using SL30PropertyGrid.Converters;

namespace SL30PropertyGrid.Converters
{
	public class EnumValueConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return EnumHelper.GetValueWrapped(value);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return ((EnumWrapper)value).Value;
		}
	}
}
