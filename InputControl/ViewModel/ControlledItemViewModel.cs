using System;
using System.Collections.Generic;
using System.Windows.Input;
using DevExpress.Mvvm;
using InputControl.DialogRelated;
using InputControl.Model;

namespace InputControl.ViewModel
{
    public delegate void ControlledItemViewModelCallBack( ControlledItemViewModel vm );

    public class ControlledItemViewModel : IDialogResultVMHelper
    {
        private readonly ControlledItemViewModelCallBack _callBack;

        private readonly Lazy<DelegateCommand> _okCommand;
        private readonly Lazy<DelegateCommand> _cancelCommand;

        public ControlledItemViewModel( ControlledItemViewModelCallBack callBack )
        {
            _callBack = callBack;
            this . _okCommand = new Lazy<DelegateCommand>( () => new DelegateCommand(() =>
            {
                _callBack(this);
                InvokeRequestCloseDialog(new RequestCloseDialogEventArgs(true));
            }, ValidateAll ) );
        }

        public IList<IItem> Items { get; set; }
        public IList<ControlledSection> Sections { get; set; }
        public ControlledSection SelectedSection { get; set; }

        public IList<Subdivision> Subdivisions { get; set; }
        public Subdivision SelectedSubdivision { get; set; }

        public IList<ItemToken> Tokens { get; set; }
        public ItemToken SelectedToken { get; set; }

        public string ControlledItemInfo { get; set; }
        public string Params { get; set; }
        public string ControlType { get; set; }
        public string MeasurementTools { get; set; }
        public string Technique { get; set; }
        public string Label { get; set; }
        public string StorageTime { get; set; }
        public string Responsible { get; set; }
        public int Section { get; set; }
        public bool VpNeed { get; set; }
        public string SupportDocument { get; set; }
        public string FileName { get; set; }

        public ICommand SaveCommand
        {
            get { return _okCommand . Value; }
        }
        public ICommand CancelComand {
            get { return _cancelCommand.Value; }
        }


        public void Cancel()
        {
        }

        public void Save()
        {
        }

        public event EventHandler<RequestCloseDialogEventArgs> RequestCloseDialog;

        private void InvokeRequestCloseDialog( RequestCloseDialogEventArgs e )
        {
            var handler = RequestCloseDialog;
            if( handler != null )
                handler( this, e );
        }

        private bool ValidateAll()
        {
            return false;
        }
    }
}
