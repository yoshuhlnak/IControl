using InputControl.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PropertyChanged;

namespace InputControl.ViewModel
{
    [ImplementPropertyChanged]
    public class ControlledItemListViewModel : IListViewModel<ControlledItem>
    {
        private readonly DbContext _context;

        public ControlledItemListViewModel( DbContext context )
        {
            _context = context;
        }

        public ICollection<ControlledItem> ListCollection { get; set; }

        public ControlledItem Focused { get; set; }

        public void Refresh()
        {
            Focused = null;
            ListCollection = _context.Set<ControlledItem>().Select(i => i).ToList();
        }

        public void AddControlledItems(IEnumerable<ControlledItem> items)
        {
            foreach (var item in items )
            {
                ListCollection.Add(item);
            }
        }
    }
}