using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using DeepEqual.Syntax;
using GalaSoft.MvvmLight;

namespace CustomWpf.Model
{
    public class AlterableObservableObject<T> : ObservableObject
    {
        public T ItemBeforeChanges;
        public T Item;

        public Dictionary<string, bool> ArePropertiesModified { get; set; }

        public AlterableObservableObject(bool isNew = false)
        {
            this.ArePropertiesModified = new Dictionary<string, bool>();
            foreach (var fieldInfo in typeof(T).GetFields())
                this.ArePropertiesModified.Add(fieldInfo.Name, isNew);

            this.PropertyChanged += this.UpdateModifiedPropertiesDictionary;
        }
        protected void UpdateModifiedPropertiesDictionary(object sender, PropertyChangedEventArgs e)
        {
            var fieldName = e.PropertyName;

            var value = this.GetValue(fieldName);
            var oldValue = this.GetOldValue(fieldName);
            this.ArePropertiesModified[fieldName] = !value.IsDeepEqual(oldValue);
        }

        protected object GetValue(string fieldName)
        {
            var fieldInfo = this.GetFieldInfo(fieldName);
            return fieldInfo.GetValue(this.Item);
        }

        protected object GetOldValue(string fieldName)
        {
            var fieldInfo = this.GetFieldInfo(fieldName);
            return fieldInfo.GetValue(this.ItemBeforeChanges);
        }

        protected FieldInfo GetFieldInfo(string fieldName)
        {
            return typeof(T).GetFields().First(f => f.Name.Equals(fieldName));
        }
    }
}