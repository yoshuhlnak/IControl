using InputControl.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Input;
using DevExpress.Mvvm;
using PropertyChanged;

namespace InputControl.ViewModel
{
    [ImplementPropertyChanged]
    public class FreeItemListViewModel : IListViewModel<FreeItem>
    {
        private readonly DbContext _context;
        private readonly ShowEditDialog _editDialogDelegate;

        public FreeItemListViewModel( DbContext context, ShowEditDialog editDialogDelegate )
        {
            _context = context;
            _editDialogDelegate = editDialogDelegate;

            SelectedItems = new List<FreeItem>();
        }

        public ICommand ConvertFocusedToContolledCommand 
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _editDialogDelegate();
                }, CanCreateControlled);
            }
        }

        public ICommand ConvertSelectedToControlledCommand
        {
            get { return new DelegateCommand( () => _editDialogDelegate(), CanCreateControlled ); }  
        }

        public ICommand RefreshCommand
        {
            get { return new DelegateCommand(Refresh); }
        }
        
        public IList<FreeItem> SelectedItems { get; private set; }

        public FreeItem Focused { get; set; }

        public bool CanCreateControlled {
            get { return SelectedItems.Count > 0; }
        }
        public bool CanCreateControlledSrl {
            get { return true; }
        }

        public ICollection<FreeItem> ListCollection { get;set; }
        public int Count { get; set; }

        /// <summary>
        /// обновление из базы 
        /// </summary>
        public void Refresh()
        {
            Clear();
            ListCollection = new ObservableCollection<FreeItem>(_context.Set<FreeItem>().Select(i => i).ToList() );
            Count = ListCollection.Count;
        }

        private void Clear()
        {
            SelectedItems . Clear();
            Focused = null;
        }
        /// <summary>
        /// удаление изделий из списка
        /// </summary>
        /// <param name="items"></param>
        public void RemoveItems(IEnumerable<FreeItem> items)
        {
            foreach (var freeItem in items)
            {
                ListCollection.Remove(freeItem);
                SelectedItems.Remove(freeItem);
                if (freeItem == Focused)
                    Focused = null;
            }
        }
    }
}
