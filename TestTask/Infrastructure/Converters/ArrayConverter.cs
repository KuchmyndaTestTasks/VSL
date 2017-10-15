using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace TestTask.Ui.Infrastructure.Converters
{
    [ValueConversion(typeof(int[]), typeof(string))]
    class ArrayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? "" : string.Join(",", (int[]) value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string source = value.ToString();
            if (!string.IsNullOrEmpty(source))
            {
                return source.Split(' ').Where(x => !string.IsNullOrEmpty(x))
                    .Select(s => System.Convert.ToInt32(s.Trim())).ToArray();
            }
            return new int[1]{0};
        }
    }
}