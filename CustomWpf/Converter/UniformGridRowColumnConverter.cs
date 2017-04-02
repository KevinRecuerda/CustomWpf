using CustomWpf.Model;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace CustomWpf.Converter
{
    public class UniformGridRowColumnConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = parameter?.ToString() == "row" ? 4 : 1;

            var group = value as CollectionViewGroup;
            var platform = group?.Name as Platform?;
            if (platform.HasValue)
            {
                result = parameter?.ToString() == "row" ? 1 : 3;
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}