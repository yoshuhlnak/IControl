using System;

namespace InputControl.DialogRelated
{
    public class RequestCloseDialogEventArgs : EventArgs
    {
        public RequestCloseDialogEventArgs( bool dialogresult )
        {
            DialogResult = dialogresult;
        }

        public bool DialogResult
        {
            get;
            set;
        }
    }
}