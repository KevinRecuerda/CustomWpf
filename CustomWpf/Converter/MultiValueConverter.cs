using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using CustomWpf.Model;

namespace CustomWpf.Converter
{
    public class MultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var dataGridCell = values[0] as DataGridCell;
            if (dataGridCell == null || dataGridCell.Column == null)
                return null;

            var isModifiedPath = dataGridCell.Column.GetIsModifiedPath();
            if (string.IsNullOrEmpty(isModifiedPath))
                return null;

            if (isModifiedPath.Contains("["))
            {
                var splittedPath = isModifiedPath.Split(new [] { "[", "]" }, StringSplitOptions.RemoveEmptyEntries);
                var dictionaryName = splittedPath[0];
                var key = splittedPath[1];

                var dictionaryPropertyInfo = dataGridCell.DataContext.GetType().GetProperties().First(f => f.Name.Equals(dictionaryName));
                var dictionary = dictionaryPropertyInfo.GetValue(dataGridCell.DataContext) as Dictionary<string, bool>;
                if (dictionary == null)
                    return null;

                bool isModified;
                dictionary.TryGetValue(key, out isModified);

                return isModified;
            }

            var propertyInfo = dataGridCell.DataContext.GetType().GetProperties().First(f => f.Name.Equals(isModifiedPath));
            return propertyInfo.GetValue(dataGridCell.DataContext);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}