using InputControl.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace InputControl.ViewModel
{
    public class FreeItemListViewModel : IListViewModel<FreeItem>
    {
        public FreeItemViewModel()
        {
            SelectedItems = new List<FreeItem>();
            }

        public IList<FreeItem> SelectedItems { get; private set; }

        public FreeItem Focused
        {
            get;

            set;
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

        public void Refresh()
        {
            throw new NotImplementedException();
        }

        public void AddSelectedToControl()
        {
        }
    }
}
