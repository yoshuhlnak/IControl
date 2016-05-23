using InputControl.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace InputControl.ViewModel
{
    public class ControlledItemListViewModel : IListViewModel<ControledItem>
    {
        private readonly DbContext _context;

        public ControlledItemListViewModel( DbContext context )
        {
            _context = context;
        }

        public IList<ControledItem> ListCollection { get; set; }

        public ControledItem Focused { get; set; }

        public void Refresh()
        {
            Focused = null;
            ListCollection = _context.Set<ControledItem>().Select(i => i).ToList();
        }

        public void AddControlledItems(IEnumerable<ControledItem> items)
        {
            foreach (var item in items )
            {
                ListCollection.Add(item);
            }
        }
    }
}