using System . Windows;
using InputControl.Service;
using InputControl.ViewModel;

namespace InputControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IUserService _userService;
        private readonly IDialogService _dialogService;
        public MainWindow()
        {
            InitializeComponent();
            _userService = new UserService();
            _dialogService = new DialogService();
            DataContext = new MainViewModel( _dialogService,_userService );
        }
    }
}
