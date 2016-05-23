using InputControl.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace InputControl.ViewModel
{
    public class FreeItemListViewModel : IListViewModel<FreeItem>
    {
        private readonly DbContext _context;
        public FreeItemListViewModel( DbContext context )
        {
            _context = context;
            SelectedItems = new List<FreeItem>();
        }

        public IList<FreeItem> SelectedItems { get; private set; }

        public FreeItem Focused { get; set; }

        public bool CanCreateControlled { get; set; }
        public bool CanCreateControlledSrl { get; set; }

        public IList<FreeItem> ListCollection { get; set; }
        /// <summary>
        /// обновление из базы 
        /// </summary>
        public void Refresh()
        {
            Clear();
            ListCollection = _context.Set<FreeItem>().Select(i => i).ToList();
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
