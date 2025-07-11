using BTG.ClientApp.Repositories;
using BTG.ClientApp.Services;
using BTG.ClientApp.ViewModels;
using BTG.ClientApp.Views;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
#endif


namespace BTG.ClientApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .ConfigureLifecycleEvents(events =>
                {
#if WINDOWS
                    events.AddWindows(w => {
                        w.OnWindowCreated(window => {
                            window.ExtendsContentIntoTitleBar = true;
                            IntPtr hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
                            WindowId myWndId = Win32Interop.GetWindowIdFromWindow(hWnd);
                            var _appWindow = AppWindow.GetFromWindowId(myWndId);
                            if(_appWindow.Title == "Cadastro de Clientes")
                            {
                                _appWindow.SetPresenter(AppWindowPresenterKind.Overlapped);
                                if (_appWindow.Presenter is OverlappedPresenter overlappedPresenter)
                                {
                                    overlappedPresenter.Maximize();
                                }
                            }
                        });
                    });
#endif
                });

            builder.Services.AddSingleton<AppShell>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<ClientFormPage>();

            builder.Services.AddSingleton<IClientRepository, ClientRepository>();
            builder.Services.AddSingleton<IClientService, ClientService>();

            builder.Services.AddSingleton<ClientViewModel>();
            builder.Services.AddTransient<ClientFormViewModel>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
