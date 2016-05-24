using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputControl.Model
{
    public class DataContext : DbContext
    {
        public DataContext() : base( "InputControl" )
        { 
        }

        public virtual DbSet<ControlledItem> ControlledItems { get; set; }
        public virtual DbSet<FreeItem> FreeItems { get; set; }
        public virtual DbSet<ControlledSection> ControlledSections { get; set; }
        public virtual DbSet<ItemToken> ItemTokens { get; set; }
    }
}
