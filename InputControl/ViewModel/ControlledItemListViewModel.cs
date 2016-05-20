using InputControl.Model;
using System;
using System.ComponentModel;

namespace InputControl.ViewModel
{
    public class ControlledItemListViewModel : IListViewModel<ControledItem>
    {
        public ControlledItemViewModel()
        {
        }

        public ICollectionView ListCollection
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public ControledItem Focused { get; set; }

        public void Refresh()
        {
            throw new NotImplementedException();
        }
    }
}