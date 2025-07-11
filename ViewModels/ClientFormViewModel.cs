using BTG.ClientApp.Helpers;
using BTG.ClientApp.Models;
using BTG.ClientApp.Services;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;


namespace BTG.ClientApp.ViewModels
{
    [QueryProperty(nameof(ClientId), "id")]
    public class ClientFormViewModel : BaseViewModel
    {
        private readonly IClientService _clientService;

        public event Action? RequestClose;

        private Guid _clientId;

        public string ClientId
        {
            set
            {
                if(Guid.TryParse(value, out var id))
                {
                    _clientId = id;
                    LoadClient();
                }
            }
        }

        private string _name = string.Empty;
        private string _lastname = string.Empty;
        private int _age;
        private string _address = string.Empty;

        public string Name { get => _name; set => SetProperty(ref _name, value); }
        public string Lastname { get => _lastname; set => SetProperty(ref _lastname, value); }
        public int Age { get => _age; set => SetProperty(ref _age, value); }
        public string Address { get => _address; set => SetProperty(ref _address, value); }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public ClientFormViewModel(IClientService clientService)
        {
            _clientService = clientService;

            SaveCommand = new Command(Save);
            CancelCommand = new Command(Cancel);

            LoadClient();
        }

        private void LoadClient()
        {
            if(_clientId != Guid.Empty)
            {
                var client = _clientService.GetById(_clientId);

                if(client != null)
                {
                    Name = client.Name;
                    Lastname = client.Lastname;
                    Age = client.Age;
                    Address = client.Address;
                }
            }
        }

        public void LoadClientById(Guid id)
        {
            _clientId = id;
            LoadClient();
        }

        private async void Save() 
        {
            if(string.IsNullOrWhiteSpace(Name) || Age <= 0)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Nome e idade são obrigatórios!", "OK");
                return;
            }

            if (Age < 1 || Age > 120)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Idade deve ser entre 1 e 120.", "OK");
                return;
            }

            var client = new Client 
            {
                Id = _clientId == Guid.Empty ? Guid.NewGuid() : _clientId,
                Name = Name,
                Lastname = Lastname,
                Age = Age,
                Address = Address
            };

            if(_clientId == Guid.Empty)
                _clientService.Add(client);
            else
                _clientService.Update(client);

            WeakReferenceMessenger.Default.Send(new ClientChangedMessage());

            RequestClose?.Invoke();
        }

        private void Cancel()
        {
            RequestClose?.Invoke();
        }
    }
}
