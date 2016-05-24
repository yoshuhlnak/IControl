using System;

namespace InputControl.DialogRelated
{
    public interface IDialogResultVMHelper
    {
        event EventHandler<RequestCloseDialogEventArgs> RequestCloseDialog;
    }
}