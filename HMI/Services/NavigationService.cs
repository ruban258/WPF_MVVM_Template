using CommunityToolkit.Mvvm.ComponentModel;
using HMI.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMI.Services
{
    internal class NavigationService: ObservableObject, INavigationService
    {
        private readonly Func<Type, ObservableObject> _viewModelFactory;
        private ObservableObject _currentView;
        public NavigationService(Func<Type, ObservableObject> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
            _currentView = _viewModelFactory.Invoke(typeof(HomeViewModel));
        }
        public ObservableObject CurrentView
        {
            get 
            {                
                return _currentView;

            } 
            private set 
            {
                _currentView = value;
                OnPropertyChanged();
            } 
        } 
       
        public void NavigateTo<TviewModel>() where TviewModel : ObservableObject
        {
            var viewModel =_viewModelFactory.Invoke(typeof(TviewModel));
            CurrentView = viewModel;
        }
    } 
}
