using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MyStocks.Converters
{
    public class TopmostToContentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isTopmost)
            {
                return isTopmost ? "📍" : "📌";
            }
            return "📌"; // 默认值
        }

        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null; // 不需要反向转换
        }
    }
}
