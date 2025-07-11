using BTG.ClientApp.Helpers;
using BTG.ClientApp.Models;
using BTG.ClientApp.Services;
using BTG.ClientApp.Views;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using System.Windows.Input;
#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
#endif

namespace BTG.ClientApp.ViewModels
{
    public class ClientViewModel : BaseViewModel
    {
        private readonly IClientService _clientService;

        private ObservableCollection<Client> _clients = new();
        public ObservableCollection<Client> Clients
        {
            get => _clients;
            set => SetProperty(ref _clients, value);
        }

        private Client? _selectedClient;

        public Client? SelectedClient { get => _selectedClient; set => SetProperty(ref _selectedClient, value); }

        public ICommand LoadClientsCommand { get; }
        public ICommand DeleteClientCommand { get; }
        public ICommand EditClientCommand { get; }
        public ICommand AddClientCommand { get; }

        public ClientViewModel(IClientService clientService)
        {
            _clientService = clientService;

            LoadClientsCommand = new Command(LoadClients);
            DeleteClientCommand = new Command<Guid>(DeleteClient);
            EditClientCommand = new Command<Guid>(EditClient);
            AddClientCommand = new Command(AddClient);

            LoadClients();

            WeakReferenceMessenger.Default.Register<ClientChangedMessage>(this, (r, m) =>
            {
                LoadClients();
            });
        }

        private void LoadClients()
        {
            Clients.Clear();
            var clientsFromService = _clientService.GetAll();
            foreach (var client in clientsFromService)
            {
                Clients.Add(client);
            }
        }

        private async void DeleteClient(Guid id)
        {
            bool confirmation = await Application.Current.MainPage.DisplayAlert("Confirmação", "Deseja realmente excluir?", "Sim", "Não");

            if (!confirmation)
                return;

            _clientService.Delete(id);
            LoadClients();
        }

        private async void EditClient(Guid id)
        {
            OpenClientForm(id);
        }

        private async void AddClient()
        {
            OpenClientForm(Guid.Empty);
        }

        private void OpenClientForm(Guid id)
        {
            var page = App.Services.GetRequiredService<ClientFormPage>();

            if(id != Guid.Empty)
            {
                page.SetClientId(id);
            }

            var window = new Window(page)
            {
                Title = id != Guid.Empty ? "Editar Cliente" : "Novo Cliente",
                Width = 800,
                Height = 500
            };

            var displayInfo = DeviceDisplay.MainDisplayInfo;

            window.Created += (_, _) =>
            {
#if WINDOWS
                var platformWindow = window.Handler.PlatformView as Microsoft.UI.Xaml.Window;
                var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(platformWindow);

                int screenWidth = (int)displayInfo.Width;
                int screenHeight = (int)displayInfo.Height;

                var windowWidth = 800;
                var windowHeight = 500;

                var left = (screenWidth - windowWidth) / 2;
                var top = (screenHeight - windowHeight) / 2;

                Microsoft.UI.Windowing.AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hwnd));

                appWindow.MoveAndResize(new Windows.Graphics.RectInt32
                {
                    X = left,
                    Y = top,
                    Width = windowWidth,
                    Height = windowHeight
                });

                appWindow.SetPresenter(AppWindowPresenterKind.Overlapped);
#endif
            };

            Application.Current.OpenWindow(window);
        }
    }
}
