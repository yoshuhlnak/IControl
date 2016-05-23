using System.Collections.Generic;
using System.ComponentModel;
using InputControl.Model;

namespace InputControl.ViewModel
{
    public interface IListViewModel<T> where T : BaseEntity
    {
        IList<T> ListCollection { get; set; }
        T Focused { get;set; }

        void Refresh();
    }
}