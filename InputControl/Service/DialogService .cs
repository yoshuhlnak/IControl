namespace InputControl.Service
{
    public class DialogService : IDialogService 
    {
        public bool? ShowDialog(string title, object datacontext)
        {
            var win = new DialogWindow
            {
                Title = title,
                DataContext = datacontext
            };

            return win . ShowDialog();
        }
    }
}