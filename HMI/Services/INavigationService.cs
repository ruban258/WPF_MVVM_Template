using CommunityToolkit.Mvvm.ComponentModel;

namespace HMI.Services
{
    public interface INavigationService
    {
        ObservableObject CurrentView { get;}
        void NavigateTo<T>()where T:ObservableObject;
    }
   
        
}
