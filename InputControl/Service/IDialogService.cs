namespace InputControl.Service
{
    public interface IDialogService
    {
        bool? ShowDialog( string title, object datacontext );  
    }
}