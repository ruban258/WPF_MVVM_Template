using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HMI.Services;


namespace HMI.MVVM.ViewModel
{
    public partial class MainViewModel: ObservableObject
    {
        private INavigationService? _navigationService;
        private RelayCommand? _navigateToSettingsCommand;
        private RelayCommand? _navigateToHomeCommand;

        public MainViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;            
        }
        public INavigationService NavigationService 
        {
            get 
            {
                if (_navigationService == null)
                {
                    throw new InvalidOperationException("NavigationService is null");
                }
                return _navigationService;
            }
            set 
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }

        #region Commands
        public IRelayCommand NavigateToSettings => _navigateToSettingsCommand ??= new RelayCommand(() => NavigationService.NavigateTo<SettingsViewModel>());

        public IRelayCommand NavigateToHome => _navigateToHomeCommand ??= new RelayCommand(() => NavigationService.NavigateTo<HomeViewModel>());
        #endregion


    }
}
