using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace CustomWpf.Model
{
    public static class DataGridCellStyleHelper
    {
        public static readonly DependencyProperty IsModifiedProperty = DependencyProperty.RegisterAttached(
               "IsModified", 
               typeof(BindingBase), 
               typeof(DataGridCellStyleHelper),
               new FrameworkPropertyMetadata(default(BindingBase), FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.AffectsMeasure, IsModifiedPropertyCallback));

        public static readonly DependencyProperty IsModifiedPathProperty = DependencyProperty.RegisterAttached(
               "IsModifiedPath",
               typeof(string),
               typeof(DataGridCellStyleHelper),
               new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.AffectsMeasure, IsModifiedPropertyCallback));

        //[AttachedPropertyBrowsableForType(typeof(DataGridCell))]
        //public static bool GetIsModified(UIElement element)
        //{
        //    return (bool)element.GetValue(IsModifiedProperty);
        //}

        //public static void SetIsModified(UIElement element, bool value)
        //{
        //    element.SetValue(IsModifiedProperty, value);
        //}
        public static BindingBase GetIsModified(this DataGridColumn column)
        {
            if (column == null)
                throw new ArgumentNullException(nameof(column));

            return (BindingBase)column.GetValue(IsModifiedProperty);
        }

        public static void SetIsModified(this DataGridColumn column, BindingBase value)
        {
            if (column == null)
                throw new ArgumentNullException(nameof(column));

            column.SetValue(IsModifiedProperty, value);
        }


        public static string GetIsModifiedPath(this DependencyObject obj)
        {
            return (string)obj.GetValue(IsModifiedPathProperty);
        }
        public static void SetIsModifiedPath(this DependencyObject obj, string value)
        {
            obj.SetValue(IsModifiedPathProperty, value);
        }
        

        private static void IsModifiedPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var a = 1;
        }
    }
}