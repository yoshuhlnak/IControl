namespace InputControl.Model
{
    public class FreeItem : BaseEntity, IItem
    {
        //public int Id { get; set; }
        public string Designation { get; set; }
        public string Name { get; set; }
        public string PurchaseType { get; set; }
    }
}
