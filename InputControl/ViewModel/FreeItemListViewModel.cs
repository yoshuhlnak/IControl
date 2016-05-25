using InputControl.Model;
using System.Collections.Generic;

namespace InputControl.ViewModel
{
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
                    var selectedList = new List<FreeItem>(SelectedItems);
                    SelectedItems = new List<FreeItem>();
                    SelectedItems.Add(Focused);
                    _editDialogDelegate();
                    SelectedItems = selectedList; // to return selection
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
            get { return true; }
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
