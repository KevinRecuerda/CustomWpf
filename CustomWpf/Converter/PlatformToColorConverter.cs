using CustomWpf.Model;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace CustomWpf.Converter
{
    public class PlatformToColorConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //var color = Colors.LightGray;
            var color = Colors.Transparent;

            var platform = value as Platform?;
            if (platform.HasValue)
            {
                switch (platform)
                {
                    case Platform.Daily:
                        color = Colors.OrangeRed;
                        break;
                    case Platform.Weekly:
                        color = Colors.MediumSeaGreen;
                        break;
                    case Platform.Monthly:
                        color = Colors.CornflowerBlue;
                        break;
                    case Platform.Annual:
                        color = Colors.PaleVioletRed;
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