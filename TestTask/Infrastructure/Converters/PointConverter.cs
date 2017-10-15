using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace TestTask.Ui.Infrastructure.Converters
{
    [ValueConversion(typeof(((char row, int col) first, (char row, int col) second)?), typeof(string))]
    class PointConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string source = value.ToString();
            if (!string.IsNullOrEmpty(source))
            {
                ((char row, int col) first, (char row, int col) second) pointTuple;

                var splited = source.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                List<(char row, int col)> list=new List<(char, int)>();
                foreach (var s in splited)
                {
                    var _char = s[0];
                    int digit = (int)Char.GetNumericValue(s[1]);
                    list.Add((_char,digit));
                }
                pointTuple.first = list.First();
                pointTuple.second = list.Last();
                return pointTuple;
            }
            return null;
        }
    }
}
