using System.Collections.Generic;
using InputControl.Model;

namespace InputControl.ViewModel
{
    public delegate void ShowEditDialog();

    public interface IListViewModel<T> //where T : BaseEntity
    {
        ICollection<T> ListCollection { get; set; }
        T Focused { get;set; }

        void Refresh();
    }
}