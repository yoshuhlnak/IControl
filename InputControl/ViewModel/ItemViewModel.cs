using System.ComponentModel;
using InputControl.Model;

namespace InputControl.ViewModel
{
    public abstract class ListViewModel<T> where T:BaseEntity
    {
        public ICollectionView ListCollection { get; set; }

        public abstract void Refresh();
    }
}