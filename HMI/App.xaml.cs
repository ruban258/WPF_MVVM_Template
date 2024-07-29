using CommunityToolkit.Mvvm.ComponentModel;
using CustomControls;
using HMI.MVVM.View;
using HMI.MVVM.ViewModel;
using HMI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.Windows;
using System.Windows.Media;

namespace HMI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
          _host = CreateHostBuilder().Build();
        }
        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();
            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
        static IHostBuilder CreateHostBuilder()
        {
            var host = Host.CreateDefaultBuilder()
           .ConfigureAppConfiguration((context, config) =>
           {
               // Ensure the appsettings.json file is included
               config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
           })
           .ConfigureServices((context, services) =>
           {
               // Register the DbContext with the connection string from appsettings.json
               //var connectionString = context.Configuration.GetConnectionString("DefaultConnection");
               //services.AddDbContext<AgproContext>(options => options.UseSqlServer(connectionString));
               // Register other services
               services.AddSingleton<MainViewModel>();  
               services.AddSingleton<HomeViewModel>();              
               services.AddSingleton<SettingsViewModel>();
               services.AddSingleton<INavigationService, NavigationService>();
               services.AddSingleton<Func<Type, ObservableObject>>(provider => viewModelType => (ObservableObject)provider.GetRequiredService(viewModelType));
               services.AddSingleton<MainWindow>(provider => new MainWindow 
               {
                   DataContext = provider.GetRequiredService<MainViewModel>()
               });
           });
            return host;
        }

    }

}
