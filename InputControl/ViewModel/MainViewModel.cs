using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Core.Model;
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

        /// <summary>
        /// Show add new items to controlled list dialog 
        /// </summary>
        private void ShowAddFreeItemsDialog()
        {
            var dialogViewModel = new ControlledItemViewModel( ConvertFreeItemsToControlled ) ;
            InitializeDialogViewModel(dialogViewModel, FreeItemListViewModel.SelectedItems.OfType<IItem>().ToList());
            _dialogService.ShowDialog( "Добавить изделия в перечень", dialogViewModel );
        }

        /// <summary>
        /// show edit controlled list items dialog
        /// </summary>
        private void ShowSaveControlledChanges()
        {
            var dialogViewModel = new ControlledItemViewModel( SaveChangesToControlled );
            InitializeDialogViewModel( dialogViewModel, new List<IItem>(){ ControlledItemListViewModel.Focused } );
            _dialogService.ShowDialog( "Изменить изделия в перечне", dialogViewModel);
        }

        /// <summary>
        /// Saves info from ControlledItemViewModel to db
        /// </summary>
        /// <param name="viewModel"></param>
        private void ConvertFreeItemsToControlled(ControlledItemViewModel viewModel)
        {
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
                //TODO: Add file saving
                newItems.Add( newItem );
            }
            _context.SaveChanges();

            FreeItemListViewModel.RemoveItems(viewModel.Items.OfType<FreeItem>());  // delete from free items
            ControlledItemListViewModel.AddControlledItems( newItems );             // add to controlled without refreshing from db
        }

        /// <summary>
        /// Initializes ControlledItemViewModel( loads combobox lists and initialize Items from SelectedItems of FreeItemListViewModel )
        /// </summary>
        /// <param name="viewModel">viewModel to initialize</param>
        /// <param name="items">items to edit</param>
        private void InitializeDialogViewModel(ControlledItemViewModel viewModel, IList<IItem> items )
        {
            viewModel.Sections = _context.Set<ControlledSection>().ToList();
            viewModel.Subdivisions = _context.Set<Subdivision>().ToList();
            viewModel.Tokens = _context.Set<ItemToken>().ToList(); 

            viewModel.Items = items;

            if( items.Count == 1 && items.ElementAt(0) is ControlledItem )
            {
                SetDialogViewModelField(viewModel, items.ElementAt(0) as ControlledItem);
            }
        }
        /// <summary>
        /// Fill viewModel properties from item properties
        /// </summary>
        /// <param name="viewModel">viewModel, which properties to fill</param>
        /// <param name="item">source - item's properties</param>
        private void SetDialogViewModelField( ControlledItemViewModel viewModel, ControlledItem item)
        {
            viewModel.SelectedSection = viewModel.Sections.FirstOrDefault( section => section == item.ControlledSection );
            viewModel.SelectedSubdivision = viewModel.Subdivisions.FirstOrDefault(subdiv => subdiv == item.Subdiv);
            viewModel.SelectedToken = viewModel.Tokens.FirstOrDefault(token => token == item.Token);

            viewModel.ControlledItemInfo = item.ControlledItemInfo;
            viewModel.Params = item.Params;
            viewModel.ControlType = item.ControlType;
            viewModel.MeasurementTools = item.MeasurementTools;
            viewModel.Technique = item.Technique;
            viewModel.Label = item.Label;
            viewModel.StorageTime = item.StorageTime;
            viewModel.Responsible = item.Responsible;
            viewModel.VpNeed = item.VpNeed;
            viewModel.SupportDocument = item.SupportDocument;
            viewModel.FileName = ""; //TODO: add file name filling
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