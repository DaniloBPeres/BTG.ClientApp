using CommunityToolkit.Mvvm.ComponentModel;

namespace BTG.ClientApp.Models
{
    public partial class Client : ObservableObject
    {
        [ObservableProperty]
        private Guid _id = Guid.NewGuid(); // Campo privado para a propriedade Id

        [ObservableProperty]
        private string _name = string.Empty; // Campo privado para a propriedade Name

        [ObservableProperty]
        private string _lastname = string.Empty; // Campo privado para a propriedade Lastname

        [ObservableProperty]
        private int _age; // Campo privado para a propriedade Age

        [ObservableProperty]
        private string _address = string.Empty; // Campo privado para a propriedade Address

        public string FullName => $"{Name} {Lastname}";

        partial void OnNameChanged(string value)
        {
            OnPropertyChanged(nameof(FullName));
        }

        partial void OnLastnameChanged(string value)
        {
            OnPropertyChanged(nameof(FullName));
        }
    }
}
