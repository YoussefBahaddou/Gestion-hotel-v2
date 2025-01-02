//using Management_Hotel.Connection;
using Management_Hotel.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace Management_Hotel.ViewModels
{
    public class ClientViewModel
    {
        private readonly HotelDbContext _context;
        public ObservableCollection<Client> Clients { get; set; }

        public ClientViewModel()
        {
            _context = new HotelDbContext();
            LoadClients();
        }

        private void LoadClients()
        {
            var clients = _context.Clients.ToList();
            Clients = new ObservableCollection<Client>(clients);
        }


        public bool AddClient(Client client)
        {
            try
            {
                _context.Clients.Add(client);
                _context.SaveChanges();
                Clients.Add(client);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void UpdateClient(Client client)
        {
            _context.Clients.Update(client);
            _context.SaveChanges();
            LoadClients();
        }

        public void DeleteClient(int clientId)
        {
            var client = _context.Clients.Find(clientId);
            if (client != null)
            {
                _context.Clients.Remove(client);
                _context.SaveChanges();
                Clients.Remove(client);
            }
        }
    }
}
