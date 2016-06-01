using System.Data.Entity;

namespace InputControl.Model
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base( "name=InputControlConnection" )
        {
            Database . SetInitializer<DataContext>( new CreateDatabaseIfNotExists<DataContext>() );
           //Database . SetInitializer<DataContext>( new DropCreateDatabaseAlways<DataContext>());
        }

        public virtual DbSet<ControlledItem> ControlledItems { get; set; }
        public virtual DbSet<FreeItem> FreeItems { get; set; }
        public virtual DbSet<ControlledSection> ControlledSections { get; set; }
        public virtual DbSet<ItemToken> ItemTokens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}
