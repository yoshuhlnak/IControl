using System;

namespace InputControl.Utils
{

    public interface IWeakEventHandler<TE>
        where TE : EventArgs
    {
        EventHandler<TE> Handler { get; }
    }


    public delegate void UnregisterCallback<TE>( EventHandler<TE> eventHandler )
    where TE : EventArgs;

}