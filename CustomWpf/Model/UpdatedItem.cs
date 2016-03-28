using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace CustomWpf.Model
{
    public class UpdatedItem<T> : ObservableObject
    {
        public T Item { get; set; }

        public bool IsUpdated { get; set; }
    }
}