using BTG.ClientApp.Models;
using System.Collections.ObjectModel;

namespace BTG.ClientApp.Repositories
{
    public interface IClientRepository
    {
        ObservableCollection<Client> GetAll();
        void Add(Client client);
        void Update(Client client);
        void Delete(Guid id);
        Client? GetById(Guid id);

        void Load();
        void Save();
    }
}
