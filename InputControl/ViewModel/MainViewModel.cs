using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DevExpress.Mvvm;
using InputControl.Model;
using InputControl.Service;
using PropertyChanged;
using IDialogService = InputControl.Service.IDialogService;

namespace InputControl.ViewModel
{
    [ImplementPropertyChanged]
    public class MainViewModel
    {
        private readonly IDialogService _dialogService;
        private readonly DbContext _context;
        private readonly IUserService _userService;
        public FreeItemListViewModel FreeItemListViewModel { get; private set; }
        public ControlledItemListViewModel ControlledItemListViewModel { get; private set; }
       

        public MainViewModel( IDialogService dialogService, IUserService userService )
        {
            _dialogService = dialogService;
            _userService = userService;
            _context = new DataContext();

            FreeItemListViewModel = new FreeItemListViewModel(_context, ShowAddFreeItemsDialog );
            ControlledItemListViewModel = new ControlledItemListViewModel(_context);
        }

        private void ShowAddFreeItemsDialog()
        {
            var dialogViewModel = new ControlledItemViewModel( ConvertFreeItemsToControlled ) ;
            InitializeDialogViewModel( dialogViewModel );
            _dialogService.ShowDialog( "Добавить изделия в перечень", dialogViewModel );
        }

        private void ShowSaveControlledChanges()
        {
            var dialogViewModel = new ControlledItemViewModel( SaveChangesToControlled );
            InitializeDialogViewModel( dialogViewModel );
            _dialogService.ShowDialog( "Изменить изделия в перечне", dialogViewModel);
        }

        private void ConvertFreeItemsToControlled(ControlledItemViewModel viewModel)
        {
            //TODO: AddFile

            IList<ControlledItem> newItems = new List<ControlledItem>();
            foreach (var item in viewModel.Items)
            {
                var newItem = new ControlledItem()
                {
                    Designation = item.Designation,
                    Name = item.Name,
                    ControlledItemInfo = viewModel.ControlledItemInfo,
                    ControlledSection = viewModel.SelectedSection,
                    ControlType = viewModel.ControlType,
                    Date = DateTime.Now,
                    EditUserLogin = _userService.Login,
                    Label = viewModel.Label,
                    MeasurementTools = viewModel.MeasurementTools,
                    Id = 0,
                    Params = viewModel.Params,
                    Responsible = viewModel.Responsible,
                    StorageTime = viewModel.StorageTime,
                    Subdiv = viewModel.SelectedSubdivision,
                    SupportDocument = viewModel.SupportDocument,
                    Technique = viewModel.Technique,
                    Token = viewModel.SelectedToken,
                    VpNeed = viewModel.VpNeed
                };
                _context.Set<ControlledItem>().Add(newItem);
                newItems.Add( newItem );
            }
            _context.SaveChanges();

            FreeItemListViewModel.RemoveItems(viewModel.Items.OfType<FreeItem>());  // delete from free items
            ControlledItemListViewModel.AddControlledItems( newItems );             // add to controlled without refreshing from db
        }

        private void InitializeDialogViewModel(ControlledItemViewModel viewModel)
        {
        }

        private void SaveChangesToControlled(ControlledItemViewModel viewModel)
        {
            //TODO: change file if it has been changed, bearing in mind that it can only be added, not replaced
            foreach( var item in viewModel.Items.OfType<ControlledItem>() )
            {
                item.ControlledSection = viewModel.SelectedSection;
                item.ControlledItemInfo = viewModel.ControlledItemInfo;
                item.ControlType = viewModel.ControlType;
                item.Date = DateTime.Now;
                item.EditUserLogin = _userService.Login;
                item.Label = viewModel.Label;
                item.MeasurementTools = viewModel.MeasurementTools;
                item.Params = viewModel.Params;
                item.Responsible = viewModel.Responsible;
                item.StorageTime = viewModel.StorageTime;
                item.Subdiv = viewModel.SelectedSubdivision;
                item.SupportDocument = viewModel.SupportDocument;
                item.Technique = viewModel.Technique;
                item.Token = viewModel.SelectedToken;
                item.VpNeed = viewModel.VpNeed;
            }
            _context.SaveChanges();
        }

    }
}