using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using CustomWpf.Model;

namespace CustomWpf.Converter
{
    public class AppStatusToColorConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = Colors.Transparent;

            var platform = value as AppStatus?;
            if (platform.HasValue)
            {
                switch (platform)
                {
                    case AppStatus.Running:
                        color = Colors.LightGreen;
                        break;
                    case AppStatus.Stopped:
                        color = Colors.LightCoral;
                        break;
                    case AppStatus.Indeterminated:
                        color = Colors.LightSalmon;
                        break;
                }
            }

            return new SolidColorBrush(color);
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