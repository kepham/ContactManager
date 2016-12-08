﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ContactManager.Presenters
{
    public class PhoneConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = value as string;
            if (string.IsNullOrEmpty(result)) return result;
            string filteredResult = FilterNonNumeric(result);
            var theNumber = System.Convert.ToInt64(filteredResult);
            switch (filteredResult.Length)
            {

                case 11:
                    result = $"{theNumber:+# (###) ###-####}";
                    break;
                case 10:
                    result = $"{theNumber:(###) ###-####}";
                    break;
                case 7:
                    result = $"{theNumber:###-####}";
                    break;
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return FilterNonNumeric(value as string);
        }

        private static string FilterNonNumeric(string stringToFilter)
        {
            if (string.IsNullOrEmpty(stringToFilter)) return string.Empty;
            var filteredResult = string.Empty;
            foreach (var c in stringToFilter)
            {
                if (char.IsDigit(c))
                    filteredResult += c;
            }
            return filteredResult;
        }
    }
}
