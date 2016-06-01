using System;
using System.Collections.Generic;
using System.Windows.Input;
using Core.Model;
using DevExpress.Mvvm;
using InputControl.DialogRelated;
using InputControl.Model;
using PropertyChanged;

namespace InputControl.ViewModel
{
    public delegate void ControlledItemViewModelCallBack( ControlledItemViewModel vm );

    [ImplementPropertyChanged]
    public class ControlledItemViewModel : IDialogResultVMHelper
    {
        private readonly ControlledItemViewModelCallBack _callBack;

        private readonly Lazy<DelegateCommand> _okCommand;
        private readonly Lazy<DelegateCommand> _cancelCommand;

        public ControlledItemViewModel( ControlledItemViewModelCallBack callBack )
        {
            _callBack = callBack;
            _okCommand = new Lazy<DelegateCommand>( () => new DelegateCommand(() =>
            {
                _callBack(this);
                InvokeRequestCloseDialog(new RequestCloseDialogEventArgs(true));
            }, () => ValidateSection() && ValidateSubdiv() ) );

            _cancelCommand = new Lazy<DelegateCommand>(() =>
                new DelegateCommand(() =>
                    InvokeRequestCloseDialog(new RequestCloseDialogEventArgs(false))
                    , true));
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
        public bool VpNeed { get; set; }
        public string SupportDocument { get; set; }
        public string FileName { get; set; }

        public ICommand SaveCommand
        {
            get { return _okCommand . Value; }
        }
        public ICommand CancelCommand {
            get { return _cancelCommand.Value; }
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
            return ValidateSubdiv() && ValidateSection() && ( ValidateTextFields() || ConsultUserAboutEmptyFields() ) ;
        }

        private bool ConsultUserAboutEmptyFields()
        {
            return true; //TODO: Add user asking whether we can continue with empty fields
        }

        private bool ValidateTextFields()
        {
            return !(String.IsNullOrEmpty(ControlledItemInfo) || String.IsNullOrEmpty(Params) ||
                     String.IsNullOrEmpty(ControlType)
                     || String.IsNullOrEmpty(MeasurementTools) || String.IsNullOrEmpty(Technique) ||
                     String.IsNullOrEmpty(Label)
                     || String.IsNullOrEmpty(StorageTime));
        }

        private bool ValidateSection()
        {
            return SelectedSection != null;
        }

        private bool ValidateSubdiv()
        {
            return SelectedSubdivision != null;
        }
    }
}
