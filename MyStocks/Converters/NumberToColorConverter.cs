using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace MyStocks.Converters
{
    public class NumberToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is decimal number)
            {
                if (number > 0)
                    return new SolidColorBrush(Colors.Red);
                else if (number < 0)
                    return new SolidColorBrush(Colors.Green);
            }
            return new SolidColorBrush(Colors.Black);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}