using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace CustomWpf.Converter
{
    public class BoolToDataGridCellStyleConverter : IValueConverter
    {
        private readonly Style basicDataGridCellStyle = (Style)Application.Current.Resources["BasicDataGridCell"];
        private readonly Style modifiedDataGridCellStyle = (Style)Application.Current.Resources["ModifiedDataGridCell"];

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isModified = false;
            if (value is bool)
                isModified = (bool) value;

            return isModified ? this.modifiedDataGridCellStyle : this.basicDataGridCellStyle;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}